FROM jenkins/jenkins:lts

USER root

# Install Docker CLI inside Jenkins container
RUN apt-get update \
 && apt-get install -y docker.io \
 && apt-get clean

# Install additional recommended plugins (optional, but helpful)
RUN jenkins-plugin-cli --plugins \
    git \
    workflow-aggregator \
    nunit \
    configuration-as-code

USER jenkins
