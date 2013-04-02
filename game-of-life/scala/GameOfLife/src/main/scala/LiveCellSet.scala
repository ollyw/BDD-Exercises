package gameoflife.implementation

import scala.collection.generic.{GenericSetTemplate, GenericCompanion, CanBuildFrom}
import scala.collection.mutable.{Builder, SetBuilder}
import scala.collection.SetLike
import scala.util.Random
import scala.math.abs
import scala.language.postfixOps

class LiveCellSet(seq : LiveCell*) extends Set[LiveCell] 
                             with SetLike[LiveCell, LiveCellSet]
                             with Serializable {
    override def empty: LiveCellSet = new LiveCellSet()
    def + (elem: LiveCell) : LiveCellSet = if (seq contains elem) this 
        else new LiveCellSet(elem +: seq: _*)
    def - (elem: LiveCell) : LiveCellSet = if (!(seq contains elem)) this
        else new LiveCellSet(seq filterNot (elem ==): _*)
    def contains (elem: LiveCell) : Boolean = seq exists (elem ==)
    def iterator : Iterator[LiveCell] = seq.iterator
    
    // http://www.derekwyatt.org/2011/07/29/understanding-scala-streams-through-fibonacci/
    // Right associative for methods ending in :
    // http://locrianmode.blogspot.co.uk/2011/07/scala-by-name-parameter.html
    val stream: Stream[LiveCellSet] = {
         def loop(v: => LiveCellSet): Stream[LiveCellSet] = Stream.cons(v, {
    		val nextGen = LiveCellSet.nextGeneration(v)
	    	  if (nextGen.size == 0) {
	    		  Stream.empty[LiveCellSet]
	    	  } else {
	    		  loop(nextGen)
	    	  }
    	})
    	
    	if (this.size == 0) {
    	  	Stream.empty[LiveCellSet]
    	} else {
    		loop(this)
    	}
    }
    
    override def toString() : String = this.foldLeft("")(_ + _.toString)
    
    override def equals(other : Any) : Boolean = {
      println("using equals")
      other match {
        case that: LiveCellSet => (this &~ that).size == 0
        case _ => false
      }
    }
}

object LiveCellSet {
    def empty: LiveCellSet = new LiveCellSet()
    def newBuilder: Builder[LiveCell, LiveCellSet] = new SetBuilder[LiveCell, LiveCellSet](empty)
    def apply(elems: LiveCell*): LiveCellSet = (empty /: elems) (_ + _)
    def thingSetCanBuildFrom = new CanBuildFrom[LiveCellSet, LiveCell, LiveCellSet] {
        def apply(from: LiveCellSet) = newBuilder
        def apply() = newBuilder
    }
    def newFromRandom(maxRowIndex: Int, maxColumnIndex: Int, numberOfCells: Int) : LiveCellSet = {
      val random = new Random()
      val cellSet = LiveCellSet.newBuilder
      for (i <- 0 until numberOfCells) {
    	  var cell = LiveCell(0,0)
    	  do {
    		  cell = LiveCell(random.nextInt(maxRowIndex), random.nextInt(maxColumnIndex))
    	  } while (LiveCellSet().contains(cell))
    	  cellSet += cell;
      }
      cellSet.result()
    }
    
    def nextGeneration (cells : LiveCellSet) : LiveCellSet = {
	  val nextGeneration = LiveCellSet.newBuilder

	  for (c <- cells) {
	    val neighbours = adjacentCells(c, cells)
	    									
	    if (neighbours.size == 2 || neighbours.size == 3) {
	      nextGeneration += c
	    }
	  }
	  
	  for (location <- cells.flatMap(adjacentLocations(_))) {
		  val neighbours = adjacentCells(location, cells)
		  if (neighbours.size == 3) {
			  nextGeneration += LiveCell(location.row, location.column) 
		  }
	  }
	  
	  nextGeneration.result
	}
	
	def adjacentCells (location : Location, cells : LiveCellSet) : LiveCellSet = {
		cells.filter(neighbour => abs(location.row - neighbour.row) < 2 &&
	    									abs(location.column - neighbour.column) < 2 &&
	    									!(location.row == neighbour.row && location.column == neighbour.column ))
	}
	
	def adjacentLocations (location: Location) = {
		for (row <- location.row - 1 to location.row + 1;
		    column <- location.column - 1 to location.column + 1
		    if location.row != row && location.column != column)
		  yield PossibleLocation(row, column)
	}
}