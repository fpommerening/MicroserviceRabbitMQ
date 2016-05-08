FROM base/arch
MAINTAINER Frank Pommerening "frank@pommerening-online.de"
ENV REFRESHED_AT 2016-02-15
RUN useradd -u 1000 frank
RUN mkdir /projects
RUN chown -R frank:frank /projects
VOLUME ["/projects"]
ENTRYPOINT ["/bin/bash"]
