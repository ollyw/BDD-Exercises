package gameoflife.implementation

import scala.math.abs

class Environment (val seeds: LiveCellSet) {
	var currentCells: LiveCellSet = seeds
	
	def tick () {
	  val nextGeneration = LiveCellSet.newBuilder
	  
	  for (c <- currentCells) {
	    val neighbours = adjacentCells(c)
	    									
	    if (neighbours.size > 3) {
	      // Do nothing
	    } else {
	      nextGeneration += c
	    }
	  }
	  
	  for (location <- currentCells.flatMap(adjacentLocations(_))) {
		  val neighbours = adjacentCells(location)
		  if (neighbours.size == 3) {
			  nextGeneration += new LiveCell(location.row, location.column) 
		  }
	  }
	  
	  currentCells = nextGeneration.result
	}
	
	def adjacentCells (location : Location) : LiveCellSet = {
		currentCells.filter(neighbour => abs(location.row - neighbour.row) < 2 &&
	    									abs(location.column - neighbour.column) < 2 &&
	    									!(location.row == neighbour.row && location.column == neighbour.column ))
	}
	
	def adjacentLocations (location: Location) = {
		for (row <- location.row - 1 to location.row + 1;
		    column <- location.column - 1 to location.column + 1
		    if location.row != row && location.column != column)
		  yield PossibleLocation(row, column)
	}
}