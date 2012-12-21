package gameoflife.implementation

class PossibleLocation(val row: Int, val column: Int) extends Location

object PossibleLocation {
  def apply(row: Int, column: Int) = new PossibleLocation(row, column) 
}