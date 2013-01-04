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
}