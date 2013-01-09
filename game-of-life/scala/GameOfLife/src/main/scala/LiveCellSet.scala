package gameoflife.implementation

import scala.collection.generic.{GenericSetTemplate, GenericCompanion, CanBuildFrom}
import scala.collection.mutable.{Builder, SetBuilder}
//import scala.collection.immutable._
import scala.collection.SetLike
import scala.util.Random

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
    
    val stream: Stream[LiveCellSet] = {
    	def loop(v: LiveCellSet): Stream[LiveCellSet] = v #:: loop(new Environment(v).tick)
    	loop(this)
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
}