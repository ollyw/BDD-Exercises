package gameoflife.tests

import org.scalatest._
import org.scalatest.matchers.ShouldMatchers

import gameoflife.implementation._

class EnvironmentSpec extends FunSpec with ShouldMatchers {
  
	describe("Environment") {
		
		it("should take a list of live cells as seeds") {
			val seeds = LiveCellSet(LiveCell(0,0), LiveCell(0,1))
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
			  	val seeds = LiveCellSet(LiveCell(0,0), LiveCell(0,1), LiveCell(1,0))
				val environment = new Environment(seeds)
			  	environment.tick()
				environment.currentCells.filter(c => c.row == 0 && c.column == 0).size should equal (1)
			  	environment.currentCells.filter(c => c.row == 0 && c.column == 1).size should equal (1)
			  	environment.currentCells.filter(c => c.row == 1 && c.column == 0).size should equal (1)
			}
			
			it("should kill live cell surrounded by 4 cells") {
			  	val seeds = LiveCellSet(LiveCell(0,0), LiveCell(0,1), LiveCell(0,2),
			  							LiveCell(1,0), LiveCell(1,1))
				val environment = new Environment(seeds)
			  	environment.tick()
			  	
				environment.currentCells.filter(c => c.row == 1 && c.column == 1).size should equal (0)
			  	environment.currentCells.filter(c => c.row == 0 && c.column == 1).size should equal (0)
			}
			
			it("should create live cell in a dead location when surrounded by 3 cells") {
			  	val seeds = LiveCellSet(LiveCell(0,0), LiveCell(0,1), LiveCell(1,0))
				val environment = new Environment(seeds)
			  	environment.tick()
				environment.currentCells.filter(c => c.row == 1 && c.column == 1).size should equal (1)
			}
			
			it("should kill live cell with 1 neighbour ") {
				val environment = new Environment(LiveCellSet(LiveCell(0,0), LiveCell(0,0)))
				environment.tick()
				environment.currentCells.size should equal (0)
			}
			
			it("should kill live cell with 0 neighbours") {
				val environment = new Environment(LiveCellSet(LiveCell(0,0)))
				environment.tick()
				environment.currentCells.size should equal (0)
			}

		}
	}
}