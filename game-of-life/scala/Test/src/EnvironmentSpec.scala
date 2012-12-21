package gameoflife.tests

import scala.collection.generic.{GenericSetTemplate, GenericCompanion, CanBuildFrom}
import scala.collection.mutable.{ArrayBuffer, Builder, SetBuilder}
import scala.collection.SetLike
import scala.math.abs

import org.scalatest._
import org.scalatest.matchers.ShouldMatchers

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
}

object LiveCellSet {
    def empty: LiveCellSet = new LiveCellSet()
    def newBuilder: Builder[LiveCell, LiveCellSet] = new SetBuilder[LiveCell, LiveCellSet](empty)
    def apply(elems: LiveCell*): LiveCellSet = (empty /: elems) (_ + _)
    def thingSetCanBuildFrom = new CanBuildFrom[LiveCellSet, LiveCell, LiveCellSet] {
        def apply(from: LiveCellSet) = newBuilder
        def apply() = newBuilder
    }
}

trait Location  {
  val row : Int
  val column : Int
}

class PossibleLocation(val row: Int, val column: Int) extends Location

object PossibleLocation {
  def apply(row: Int, column: Int) = new PossibleLocation(row, column) 
}

// Live is hard, so the ratio of dead or empty cells to live cells in large
class LiveCell (val row : Int, val column : Int) extends Location {
	override def equals(other: Any) = {
		val that = other.asInstanceOf[LiveCell]
		
		that.row == this.row && that.column == this.column
	}
}

class Environment (val seeds: LiveCellSet) {
	var currentCells: LiveCellSet = seeds
	
	def tick () {
	  val nextGeneration = LiveCellSet.newBuilder
	  
	  for (c <- currentCells) {
	    val neighbours = adjacentCells(c)
	    									
	    if (neighbours.size > 3) {
	      // Do nothing
	    } else {
	      nextGeneration += c
	    }
	  }
	  
	  for (location <- currentCells.flatMap(adjacentLocations(_))) {
		  val neighbours = adjacentCells(location)
		  Console.println("Neighbours: " + neighbours.size)
		  if (neighbours.size == 3) {
			  Console.println("Adding neighbour: " + location.row + "," + location.column)
			  nextGeneration += new LiveCell(location.row, location.column) 
		  }
	  }
	  
	  currentCells = nextGeneration.result
	  Console.println("Current Cells: " + currentCells.size)
	}
	
	def adjacentCells (location : Location) : LiveCellSet = {
		currentCells.filter(neighbour => abs(location.row - neighbour.row) < 2 &&
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

class EnvironmentSpec extends FunSpec with ShouldMatchers {
  
	describe("Environment") {
		
		it("should take a list of live cells as seeds") {
			val seeds = LiveCellSet(new LiveCell(0,0), new LiveCell(0,1))
			val environment = new Environment(seeds)
			environment.currentCells.size should equal (2)
		}
		  
		describe("tick") {
			it("should return no live cells if no seeds are passed in ") {
				val environment = new Environment(LiveCellSet.empty)
				environment.tick()
				environment.currentCells.size should equal (0)
			}

			it("should return three live cells if there are 3 live cells next to each other") {
			  	val seeds = LiveCellSet(new LiveCell(0,0), new LiveCell(0,1), new LiveCell(1,0))
				val environment = new Environment(seeds)
			  	environment.tick()
				environment.currentCells.filter(c => c.row == 0 && c.column == 0).size should equal (1)
			  	environment.currentCells.filter(c => c.row == 0 && c.column == 1).size should equal (1)
			  	environment.currentCells.filter(c => c.row == 1 && c.column == 0).size should equal (1)
			}
			
			it("should kill live cell surrounded by 4 cells") {
			  	val seeds = LiveCellSet(new LiveCell(0,0), new LiveCell(0,1), new LiveCell(0,2),
			  						new LiveCell(1,0), new LiveCell(1,1))
				val environment = new Environment(seeds)
			  	environment.tick()
			  	
				environment.currentCells.filter(c => c.row == 1 && c.column == 1).size should equal (0)
			  	environment.currentCells.filter(c => c.row == 0 && c.column == 1).size should equal (0)
			}
			
			it("should create live cell in a dead location when surrounded by 3 cells") {
			  	val seeds = LiveCellSet(new LiveCell(0,0), new LiveCell(0,1), new LiveCell(1,0))
				val environment = new Environment(seeds)
			  	environment.tick()
				environment.currentCells.filter(c => c.row == 1 && c.column == 1).size should equal (1)
			}
		}
	}
}