package gameoflife.tests

import org.scalatest._
import org.scalatest.matchers.ShouldMatchers
import scala.collection.immutable.Stream
import gameoflife.implementation.LiveCell
import gameoflife.implementation.LiveCellSet
import scala.collection.immutable.Range

class StreamExampleSpec extends FeatureSpec with GivenWhenThen with ShouldMatchers {
	ignore("Scala lazy evaluation with streams") {
		scenario("Recursive call doesn't cause a stack overflow") {
		  
			given("a function which calculation which runs the square of integers")
			def calcSquare(v: => BigInt) : Stream[BigInt] = (v * v) #:: calcSquare(v + 1)
			
			when("when pop is invoked on the stack")
			val squareStream = calcSquare(0) take 4
			
			then("the third value should be 9 (3 x 3) ")
			squareStream.size should equal(4)
			squareStream.last should equal(9)
		}
	}
}