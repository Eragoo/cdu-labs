package com.Eragoo.cdu_labs.system_modeling.lab2

object NeimansRandom {
  var x0 = 3451280;

  def next(start: Int, end: Int): Double = {
    val square = x0 * x0
    x0 = square.toString.substring(square.toString.length / 2 - 2, square.toString.length / 2 + 2).toInt
    val y = x0 / 10000d
    (y * end) % (end - start) + start
  }
}
