ThisBuild / version := "0.1.0-SNAPSHOT"

ThisBuild / scalaVersion := "2.13.10"

lazy val root = (project in file("."))
  .settings(
    name := "lab2",
    idePackagePrefix := Some("com.Eragoo.cdu_labs.system_modeling.lab2")
  )

libraryDependencies += "org.scala-lang" % "scala-swing" % "2.10+"
mainClass in (Compile, run) := Some("com.Eragoo.cdu_labs.system_modeling.lab2.Main")