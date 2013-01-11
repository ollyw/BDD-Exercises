package gameoflife.implementation

// Live is hard, so the ratio of dead or empty cells to live cells in large
class LiveCell (val row : Int, val column : Int) extends Location {
	override def equals(other: Any) = {
      other match {
        case that: LiveCell => that.row == this.row && that.column == this.column
        case _ => false
      }
	}
	
	override def toString = "{row:" + this.row.toString + " , col:" + this.column.toString + "}" 
}

object LiveCell {
  def apply(row : Int, column : Int) = new LiveCell(row, column)
}