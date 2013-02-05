package models

import gameoflife.implementation._

class Game (val rows: Int, val columns: Int)

case class StartMessage (val numberOfSeeds: Int, val numberOfGenerations : Int)

case class BestMatch(val seeds: LiveCellSet, val numberOfLiveCells: Int)