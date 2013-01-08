package formatters

import play.api.libs.json._
import org.slf4j.Logger
import gameoflife.implementation._
import models._
import org.slf4j.LoggerFactory
import scala.collection.immutable.StringOps

object JsonFormats {
  
  implicit object LiveCellFormat extends Format[LiveCell] {
    def reads(json: JsValue): LiveCell = LiveCell((json \ "row").as[Int],
    												(json \ "column").as[Int])

    def writes(s: LiveCell): JsValue = Json.toJson(Map("row" -> Json.toJson(s.row),
    													"column" -> Json.toJson(s.column)))  
  }
  
  implicit object LiveCellSetFormat extends Format[LiveCellSet] {
	def reads(json: JsValue): LiveCellSet = LiveCellSet(json.as[Seq[LiveCell]]: _*)
    
	def writes(s: LiveCellSet): JsValue = Json.toJson(s.map(Json.toJson(_)))
  }
  
  implicit object GameFormat extends Format[Game] {
    def reads(json: JsValue): Game = {
    	
    	val logger = LoggerFactory.getLogger("foo")
    	logger.debug(json.toString)
    	val rows = (json \ "rows").as[String].toInt
    	val columns = (json \ "columns").as[String].toInt
    	new Game(rows, columns)
    }
    def writes(s: Game): JsValue = Json.toJson(Map("rows" -> Json.toJson(s.rows), "columns" -> Json.toJson(s.columns)))
  }
}
