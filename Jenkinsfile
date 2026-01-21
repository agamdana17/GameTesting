pipeline {
    agent { label 'Windows' }

    stages {

        stage('Checkout Source Code') {
            steps {
                git branch: 'main',
                    credentialsId: 'github-cred',
                    url: 'https://github.com/agamdana17/GameTesting.git'
            }
        }

        stage('Run Unity NUnit Tests') {
            steps {
                bat """
                "C:\\Program Files\\Unity\\Hub\\Editor\\6000.0.47f1\\Editor\\Unity.exe" ^
                -runTests ^
                -projectPath "%WORKSPACE%" ^
                -testResults "%WORKSPACE%\\TestResults.xml" ^
                -testResultsFormat junit ^
                -testPlatform editmode ^
                -batchmode ^
                -quit
                """
            }
        }

        stage('Publish NUnit Results') {
            steps {
                junit 'TestResults.xml'
            }
        }
    }

    post {
        always {
            echo "Pipeline testing game drag & drop selesai"
        }
        failure {
            echo "Terdapat kegagalan pada pengujian game"
        }
    }
}
