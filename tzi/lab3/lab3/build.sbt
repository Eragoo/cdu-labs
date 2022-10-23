ThisBuild / version := "0.1.0-SNAPSHOT"

ThisBuild / scalaVersion := "2.10.6"

lazy val root = (project in file("."))
  .settings(
    name := "lab3",
    idePackagePrefix := Some("com.Eragoo.cdu_labs.tzi")
  )
libraryDependencies += "org.scala-lang" % "scala-swing" % "2.10+"
mainClass in (Compile, run) := Some("com.Eragoo.cdu_labs.tzi.Main")
