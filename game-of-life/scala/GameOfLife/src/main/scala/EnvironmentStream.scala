package gameoflife.implementation

import scala.collection.immutable.Stream

//http://www.codecommit.com/blog/scala/infinite-lists-for-the-finitely-patient

/*class RichStream[A](str: =>Stream[A]) {
  def ::(hd: A) = Stream.cons(hd, str)
  implicit def streamToRichStream[A](str: =>Stream[A]) = new RichStream(str)

}

class EnvironmentStream extends Stream[LiveCellSet] {

}

object EnvironmentStream {
    implicit def from(n: LiveCellSet): Stream[LiveCellSet] = from(new Environment(n).tick)
}*/