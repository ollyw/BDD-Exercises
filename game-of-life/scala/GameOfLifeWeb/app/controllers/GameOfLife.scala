package controllers

import play.api._
import play.api.mvc._
import play.api.libs.json._

import gameoflife.implementation._

import formatters.JsonFormats.LiveCellSetFormat
 
object GameOfLife extends Controller {
  
  def index = Action {
    Ok(views.html.index())
  }
  
  def newGame = Action {
	val seeds = LiveCellSet(LiveCell(0,0), LiveCell(0,1))
	val environment = new Environment(seeds)
			environment.currentCells
	  Ok(Json.toJson(environment.currentCells))
  }
  
  def nextGeneration = Action(parse.json) { request =>
  	request.body.asOpt[LiveCellSet].map { seeds => 
  		Ok(Json.toJson(new Environment(seeds).tick()))
    }.getOrElse(BadRequest("Missing parameter [name]"))
  }
}