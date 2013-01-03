package controllers

import play.api._
import play.api.mvc._
import play.api.libs.json._

import gameoflife.implementation._

object Formats {
  
  implicit object LiveCellFormat extends Format[LiveCell] {
    def reads(json: JsValue): LiveCell = LiveCell((json \ "row").as[Int], (json \ "column").as[Int])

    def writes(s: LiveCell): JsValue = Json.toJson(Map("row" -> Json.toJson(s.row),
    													"column" -> Json.toJson(s.column)))  
  }
  
  implicit object LiveCellSetFormat extends Format[LiveCellSet] {
    def reads(json: JsValue): LiveCellSet = {
    		val seq = json.as[Seq[LiveCell]]
    		LiveCellSet(seq: _*)
    }
    
      def writes(s: LiveCellSet): JsValue = Json.toJson(s.map(Json.toJson(_)))
  }
}

import Formats.LiveCellSetFormat
 
object GameOfLife extends Controller {
  
  def newGame = Action {
	val seeds = LiveCellSet(LiveCell(0,0), LiveCell(0,1))
	val environment = new Environment(seeds)
			environment.currentCells
	  Ok(Json.toJson(environment.currentCells))
  }
  
  def nextGeneration = Action(parse.json) { request =>
  	request.body.asOpt[LiveCellSet].map { seeds => 
  		Ok(Json.toJson(new Environment(seeds).currentCells))
    }.getOrElse(BadRequest("Missing parameter [name]"))
  }
}