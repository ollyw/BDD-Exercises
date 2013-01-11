package controllers

import play.api._
import play.api.mvc._
import play.api.libs.json._

import gameoflife.implementation._
import models._;
import formatters.JsonFormats._;
 
object GameOfLife extends Controller {
  
  def index = Action {
    Ok(views.html.index())
  }
  
  def newGame = Action(parse.json) { request => {
	  val game = request.body.as[Game]
	  val seeds = LiveCellSet.newFromRandom(game.rows, game.columns, 20)
	  val environment = new Environment(seeds)
	  
	  Ok(Json.toJson(environment.currentCells))
  	}
  }
  
  def nextGeneration = Action(parse.json) { request =>
  	request.body.asOpt[LiveCellSet].map { seeds => 
  		Ok(Json.toJson(new Environment(seeds).tick()))
    }.getOrElse(BadRequest("Missing parameter [name]"))
  }
  
  def livelyGame = Action {
    val seeds = (1 to 1000).map((i: Int) => LiveCellSet.newFromRandom(10, 10, 10) )
    
    val gameOfLifeStream = seeds.par.map(s => (s.stream take 200)).maxBy(_.last.size)
    
    Ok(Json.toJson(new Environment(gameOfLifeStream.head).tick()))
  }
}