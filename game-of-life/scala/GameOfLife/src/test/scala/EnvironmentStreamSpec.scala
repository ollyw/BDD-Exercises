package gameoflife.tests

import org.scalatest._
import org.scalatest.matchers.ShouldMatchers
import scala.collection.immutable.Stream

import gameoflife.implementation._

class EnvironmentStreamSpec extends FunSpec with ShouldMatchers {
  
	describe("LiveCellSet") {
		  
		describe("stream property") {
			/*
			it("should return a stream pointing to the seeds passed in ") {
				val seeds = LiveCellSet(LiveCell(0, 0), LiveCell(0, 1))
				val gameOfLifeStream = seeds.stream

				gameOfLifeStream.head should equal (seeds)
			}
*/
			it("should return each frame using take") {
				// Test this using a bi-stable oscillating pattern in the game of life
				val state1 = LiveCellSet(LiveCell(1, 0), LiveCell(1, 1), LiveCell(1, 2))
				val state2 = LiveCellSet(LiveCell(0, 1), LiveCell(1, 1), LiveCell(2, 1))
				
				val gameOfLifeStream = state1.stream take 2
								
				gameOfLifeStream.size should equal (2)
				gameOfLifeStream.head.forall(state1.contains) should equal (true)
				gameOfLifeStream.last.forall(state2.contains) should equal (true)
			}

		  
			it("should terminate once the cells die") {
			  // A single cell should die on the second evaluation of the rules
			  // meaning that only a single item will exist in the stream
			  val seed = LiveCellSet(LiveCell(1, 0))
			  val gameOfLifeStream = seed.stream take 20
			  gameOfLifeStream.size should equal (1)
			}

			it("should terminate when there are no live cells in an item") {
			  // A single cell should die on the second evaluation of the rules
			  // meaning that only a single item will exist in the stream
			  val seed = LiveCellSet.empty
			  lazy val gameOfLifeStream = seed.stream take 5
			  gameOfLifeStream.size should equal (0)
			}
		}
	}
}