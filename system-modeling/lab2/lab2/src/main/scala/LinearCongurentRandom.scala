package com.Eragoo.cdu_labs.system_modeling.lab2

object LinearCongurentRandom {
  var x0 = 3451
  val k = 1314
  val c = 513

  def next(start: Int, end: Int): Double = {
    x0 = (k * x0 + c) % (end + 1)
    val y = x0 / (end + 1d)
    (y * end) % (end - start) + start
  }
}
