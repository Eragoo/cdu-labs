package com.Eragoo.cdu_labs.system_modeling.lab2

object Main {
  var startNum = 3450;

  def main(args: Array[String]): Unit = {
    for (i <- 1 to 5) {
      println(neimansRandom(1, 10))
    }
  }

  def neimansRandom(start: Int, end: Int): Int = {

    var s = startNum;
    for (i <- 1 to 100) {
      val square = s * s
      s = square.toString.substring(square.toString.length / 2 - 2, square.toString.length / 2 + 2).toInt
    }
    startNum = startNum + 1;
    s % (end - start) + start
  }
}
