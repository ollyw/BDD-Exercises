import sbt._
import Keys._
import PlayProject._

object ApplicationBuild extends Build {

    val appName         = "GameOfLifeWeb"
    val appVersion      = "1.0-SNAPSHOT"

    val appDependencies = Seq(
    	"gameoflife" %% "logic" % "0.0.1-SNAPSHOT"//,
    	//"org.scala-lang" % "scala-compiler" % "2.9.1",
    	//"org.scala-tools" %% "scala-stm" % "0.3"
    )

    val main = PlayProject(appName, appVersion, appDependencies, mainLang = SCALA).settings(
        scalaVersion := "2.9.1",
        resolvers += (
            Resolver.url("my-test-repo", url("file://"+Path.userHome.absolutePath+"/.ivy2/local"))( Resolver.ivyStylePatterns )
        		//"Local Ivy Repository" at "file://"+Path.userHome.absolutePath+"/.ivy2/local"
        )
    	//resolvers += (
    	//			"Local Maven Repository" at "file:///C:/Users/oliver.wickham/.m2/repository"
    	//			)    
    )

}
