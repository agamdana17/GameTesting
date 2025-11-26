pipeline {
  agent none
  stages {
    stage ('Checkout'){
      agent{ label 'Windows'}
      steps {
        git branch: 'main',
          credetntialsId:'github-token',
          url: ''
      }
    }
  }
}
