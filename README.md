# Company.Api.Facade

# Introduction 

This is a facacde API to transform an API XML response to a JSON response. 

# Getting Started

1. Clone the git repo
2. Open the `Mwnz.Company.Xml.Source.Facade.sln` in Visual Studio.
3. Build and run.

The Open API spec is in the project.

# Build and Test

To build the docker image, run the following;
```
docker build -t companyapifacade .
```

To start the container, run the following;
```
docker run -p 5001:5001 companyapifacade -d
```

By default Kestrel is configured to listen on port 5001. If this port is already allocated on your host machine, you can change the host port binding e.g. -p 5002:5002.
```
docker run --env PORT_NUMBER=5002 -p 5002:5002 companyapifacade
```

To test; navigate to `http://localhost:5001/swagger`. This will load the (Swashbuckle) Swagger UI. Note: if you're using docker-machine, replace `localhost` with the docker-machine IP.


# Contribute

Contributions to Company.Api.Facade are welcome. Here is how you can contribute to Company.Api.Facade:

* Submit bugs and help verify fixes.
* Submit pull requests for bug fixes and features.
