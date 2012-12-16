package gameoflife.tests

import scala.collection.mutable.ArrayBuffer
import scala.math.abs

import org.scalatest._
import org.scalatest.matchers.ShouldMatchers

class LiveCell (val row : Int, val column : Int) {
  
}

class Environment (val seeds: Array[LiveCell]) {
	var currentCells: Seq[LiveCell] = seeds
	
	def tick () {
	  val nextGeneration = ArrayBuffer[LiveCell]()
	  
	  for (c <- currentCells) {
	    val neighbours = currentCells.filter(neighbour => abs(c.row - neighbour.row) < 2 &&
	    									abs(c.column - neighbour.column) < 2 &&
	    									c != neighbour)
	    if (neighbours.length > 3) {
	      // Do nothing
	    } else {
	      nextGeneration += c
	    }									
	  }
	  
	  currentCells = nextGeneration
	}
}

class EnvironmentSpec extends FunSpec with ShouldMatchers {
  
	describe("Environment") {
		
		it("should take a list of live cells as seeds") {
			val seeds = Array(new LiveCell(0,0), new LiveCell(0,0))
			val environment = new Environment(seeds)
			environment.currentCells.length should equal (2)
		}
		  
		describe("tick") {
			it("should return no live cells if no seeds are passed in ") {
				val environment = new Environment(Array[LiveCell]())
				environment.tick()
				environment.currentCells.length should equal (0)
			}

			it("should return three live cells if there are 3 live cells next to each other") {
			  	val seeds = Array(new LiveCell(0,0), new LiveCell(0,1), new LiveCell(1,0))
				val environment = new Environment(seeds)
			  	environment.tick()
				environment.currentCells.length should equal (3)
			}
			
			it("should kill live cell surrounded by 4 cells") {
			  	val seeds = Array(new LiveCell(0,0), new LiveCell(0,1), new LiveCell(0,2),
			  						new LiveCell(1,0), new LiveCell(1,1))
				val environment = new Environment(seeds)
			  	environment.tick()
			  	
			  	environment.currentCells.length should equal (3)
				environment.currentCells.filter(c => c.row == 1 && c.column == 1).length should equal (0)
			  	environment.currentCells.filter(c => c.row == 0 && c.column == 1).length should equal (0)
			}
		}
	}
}