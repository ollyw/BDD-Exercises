package gameoflife.implementation

import scala.collection.generic.{GenericSetTemplate, GenericCompanion, CanBuildFrom}
import scala.collection.mutable.{Builder, SetBuilder}
import scala.collection.SetLike
import scala.util.Random

class LiveCellSet(seq : LiveCell*) extends Set[LiveCell] 
                             with SetLike[LiveCell, LiveCellSet]
                             with Serializable {
    override def empty: LiveCellSet = new LiveCellSet()
    def + (elem: LiveCell) : LiveCellSet = if (seq contains elem) this 
        else new LiveCellSet(elem +: seq: _*)
    def - (elem: LiveCell) : LiveCellSet = if (!(seq contains elem)) this
        else new LiveCellSet(seq filterNot (elem ==): _*)
    def contains (elem: LiveCell) : Boolean = seq exists (elem ==)
    def iterator : Iterator[LiveCell] = seq.iterator
}

object LiveCellSet {
    def empty: LiveCellSet = new LiveCellSet()
    def newBuilder: Builder[LiveCell, LiveCellSet] = new SetBuilder[LiveCell, LiveCellSet](empty)
    def apply(elems: LiveCell*): LiveCellSet = (empty /: elems) (_ + _)
    def thingSetCanBuildFrom = new CanBuildFrom[LiveCellSet, LiveCell, LiveCellSet] {
        def apply(from: LiveCellSet) = newBuilder
        def apply() = newBuilder
    }
    def newFromRandom(maxRowIndex: Int, maxColumnIndex: Int, numberOfCells: Int) : LiveCellSet = {
      val random = new Random()
      val cellSet = LiveCellSet.newBuilder
      for (i <- 0 until numberOfCells) {
    	  var cell = LiveCell(0,0)
    	  do {
    		  cell = LiveCell(random.nextInt(maxRowIndex), random.nextInt(maxColumnIndex))
    	  } while (LiveCellSet().contains(cell))
    	  cellSet += cell;
      }
      cellSet.result()
    }
}