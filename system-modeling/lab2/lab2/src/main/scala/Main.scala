package com.Eragoo.cdu_labs.system_modeling.lab2

import NeimansRandom.next

import scala.swing.event.ButtonClicked
import scala.swing.{Button, Dimension, FlowPanel, Label, MainFrame, TextField}

class UI extends MainFrame {
  title = "Кухоль Лаб 2"
  preferredSize = new Dimension(700, 500)

  val myText: TextField = new TextField() {
    columns = 20
    text = "Hello, World!"
    enabled = true
  }

  val result: Label = new Label()

  val encodeButton: Button = new Button {
    text = "Encode"
    enabled = true
    reactions += {
      case ButtonClicked(_) => result.text = encode(myText.text)
    }
  }

  val decodeButton: Button = new Button {
    text = "Decode"
    enabled = true
    reactions += {
      case ButtonClicked(_) => result.text = decode(myText.text)
    }
  }

  contents = new FlowPanel(myText, encodeButton, decodeButton, result)
}

object Main {
  def main(args: Array[String]): Unit = {
    for (_ <- 1 to 5) {
      println("Neimans: " + next(1, 100))
      println("Linear: " + LinearCongurentRandom.next(1, 100))
    }
  }
}
