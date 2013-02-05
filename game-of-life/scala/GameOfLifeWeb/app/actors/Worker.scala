package actors

import akka.actor._
import akka.util.Timeout
import akka.util.duration._
import akka.dispatch._
import models._
import gameoflife.implementation._

class Worker extends Actor {
  
  def receive = {
    case StartMessage(numberOfSeeds, numberOfGenerations) => {
      
        val seeds = (1 to numberOfSeeds).map((i: Int) => LiveCellSet.newFromRandom(10, 10, 10) )
    
        val gameOfLifeStream = seeds.par.map(s => (s.stream take numberOfGenerations)).maxBy(_.last.size)

        sender ! BestMatch(gameOfLifeStream.head, gameOfLifeStream.last.size) // perform the work
    }
  }
}

object Worker {
    implicit val timeout = Timeout(10 seconds)
}
