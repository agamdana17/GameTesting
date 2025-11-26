pipeline {
    agent none

    stages {

        stage('Checkout') {
            agent { label 'Windows' }
            steps {
                git branch: 'main',
                    credentialsId: 'github-cred',
                    url: 'https://github.com/agamdana17/testinggame.git'
            }
        }

        stage('Run Unity NUnit Tests') {
            agent { label 'Windows' }
            steps {
               bat "\"C:\\Program Files\\Unity\\Hub\\Editor\\6000.0.47f1\\Editor\\Unity.exe\" -runTests -projectPath \"%cd%\" -testResults \"%cd%\\TestResults.xml\" -testResultsFormat junit -testPlatform editmode -batchmode -quit"

            }
        }

        stage('Publish NUnit Results') {
    agent { label 'Windows' }
    steps {
        nunit testResultsPattern: 'Assets/Tests/TestResults.xml'
    }
}
    }
}
