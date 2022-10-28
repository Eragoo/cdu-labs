package com.Eragoo.cdu_labs.tzi

import scala.swing._
import scala.swing.event.ButtonClicked

class UI extends MainFrame {
  title = "Кухоль ТЗІ Лаб 3"
  preferredSize = new Dimension(320, 240)

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

  val code = "aersdtfhjgkhlhjgfd"

  val alphabet: Array[Array[String]] = Array(
    Array("a", "b", "c", "d", "e", ","),
    Array("f", "g", "h", "i", "j", ":"),
    Array("k", "l", "m", "n", "o", "?"),
    Array("p", "q", "r", "s", "t", " "),
    Array("u", "v", "w", "x", "y", "z"),
    Array("!", "-", "'", "\"", "(", ")")
  )

  val hashAlphabet: Map[String, Array[Int]] = fillHasTable();

  def fillHasTable(): Map[String, Array[Int]] = {
    var hashTable: Map[String, Array[Int]] = Map()
    for (i <- alphabet.indices) {
      for (j <- alphabet(i).indices) {
        hashTable += (alphabet(i)(j) -> Array(i, j))
      }
    }

    hashTable
  }

  def encode(text: String): String = {
    text.map(_.toString.toLowerCase())
      .map(c => hashAlphabet(c).mkString)
      .mkString
  }

  def decode(text: String): String = {
    text.grouped(2)
      .map(c => alphabet(c(0).asDigit)(c(1).asDigit))
      .mkString
  }
}

object Main {
  def main(args: Array[String]): Unit = {
    val ui = new UI
    ui.visible = true

    while (true) {
      Thread.sleep(1000)
    }
  }
}
