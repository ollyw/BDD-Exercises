package formatters

import play.api.libs.json._

import gameoflife.implementation._
import models._

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
    def reads(json: JsValue): Game = new Game((json \ "rows").as[Int], (json \ "columns").as[Int])
    def writes(s: Game): JsValue = Json.toJson(Map("rows" -> Json.toJson(s.rows), "columns" -> Json.toJson(s.columns)))
  }
}
