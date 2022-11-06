package com.Eragoo.cdu_labs.system_modeling.lab2

import NeimansRandom.next

import scala.swing.event.ButtonClicked
import scala.swing.{Button, Dimension, FlowPanel, Label, MainFrame, TextField}

class UI extends MainFrame {
  title = "Кухоль Лаб 2"
  preferredSize = new Dimension(700, 500)

  val createChart = ChartFactory.createBarChart(
    "Bar Chart Example", //Chart Title
    "Year", // Category axis
    "Population in Million", // Value axis
    dataset,
    PlotOrientation.VERTICAL,
    true,true,false
  );

  contents = new FlowPanel()
}

object Main {
  def main(args: Array[String]): Unit = {
    for (_ <- 1 to 5) {
      println("Neimans: " + next(1, 100))
      println("Linear: " + LinearCongurentRandom.next(1, 100))
    }
  }
}
