# SurveySite

## Table of Contents

- [@MOM Survey Site Demo API](#mom-survey-site-demo)
  - [Overview](#overview)
    - [Technical Stack](#technical-stack)
  - [Setup](#setup)
    - [API Style](#api-style)
    - [Prerequisites](#prerequisites)
    - [Repository](#repository)
  - [Deploy to Azure](#deploy-portal)
  - [Network Setup](#network-setup)

## Overview

This project is a demonstration site for My Opinion Matters. The site is a basic survey site. When a user hits the /survey endpoint the portal will make a request to the API for a new survey.
If the user is anonymous, the IP Address will be used to determine if the user has completed all the surveys for the day. If they are logged in, then their user identifier will be used.

The survey system consists of multiple "survey banks" e.g. Political Questions/General Questions etc. In each bank, there are a set number of questions. For each question there are multiple choice answers. 

The question bank will be choosen at random. The associated questions and the current scores will be gatehered together and returned back to the portal on the inital survey load.

As the user answers each question, an API call is made to save the response for that question. The user then sees the current score for the answers of the question.

When all questions are completed, the user will be asked if they want to log-in or sign up. If they are already logged in, they will get a message saying they have completed the survey.

If the user refreshes the page, they will get another question bank and so-on until all question banks are complete for that day. Once all banks are complete for the day, the user will get a message saying they are finished for the day.

### Technical Stack

For this application, i chose .NET7.0 to create the WebAPI. I chose this as its a modern, lightweight and cross platform framework with good support base.

I have chose to use the Azure cloud for deployment of the site, so by using .NET and the microsoft tooling, it provides a seemless integration of application and deployment.

I have chose SQL Server as the database to provide an integrated platform of technologies. 

For the dependency injection, I have used AutoFac. I have used this as it provides more advanced functionality than the standard DI contained. Although not needed in this small application.

ApplicationInsights is configured to record and analyze performance of the sytem.


### Coding Styles

The API uses Command Query Separation Pattern (CQSP) to execute functionality on the system. When adding new functonality please follow this pattern.

Anything that has an impact on the database (e.g. an add/edit/delete) should be in a CommandHandler. The class name should be {FUNCTION-DESCRIPTION}CommandHandler.cs

Anything that is retrieving data from the database (e.g. a get all function) and does not impact data, should be in a QueryHandler. The class name should be {FUNCTION-DESCRIPTION}QueryHandler.cs

For example
    The function to start a survey is in "StartSurveyCommandHandler.cs"

**NOTE: It is important to follow the naming convention as AutoFac will only pick up new handlers if they have this at the end of the class name.**

Parameters for CommandHandlers should be called {PARAM}Command.cs and {PARAM}Result.cs
Parameters for QueryHandlers should be called {PARAM}Query.cs and {PARAM}Result.cs

They should be located in the Commands and Results folders in their respective sections

API controllers should use a business logic to make direct calls to the handlers. All business logic class should use an interface. The business logic class should all end in "Bl.cs".

**NOTE: This is important, if the name does not end in Bl, then AutoFac will not automatically pick it up in the dependency injection.**

The mediator is used to direct the calls to the handlers. Resolve a IMediator object into your Bl and then you can use the pattern. It will be as follows:

For CommandHandlers use,

    var RESPONSE-INSTANCE = await mMediator.Send<COMMAND-OBJECT, RESULT-OBJECT>(COMMAND-INSTANCE);

For QueryHandlers use,

    var RESPONSE-INSTANCE = await mMediator.Execute<QUERY-OBJECT, RESULT-OBJECT>(QUERY-INSTANCE);

#### DTOs

DTOs should be used for inbound and outgoing data from the API controllers. The names of the DTOs should align with their corresponding internal classes. 

For each new DTO you will need to add a mapping profile in /MappingProfile.cs e.g.

    CreateMap<Question, QuestionDto>();
    CreateMap<QuestionBank, QuestionBankDto>();
    CreateMap<SurveyAnswer, SurveyAnswerDto>();
    CreateMap<Answer, AnswerDto>();
    CreateMap<StartSurveyResult, StartSurveyResultDto>();
    CreateMap<GetQuestionBankResult, QuestionBankResultDto>();

    CreateMap<LoginResult, LoginResponseDto>();
    CreateMap<RegisterResult, RegisterResponseDto>();

If the property names don't match, you will need to directly map them in the profile. Only map and expose the relevant information. 

**Do not include properties that are not needed by the public portal.**

## Setup

### Prerequisites

Please install the following tools and packages to run the apps:

- .NET7.0 SDK [download](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks)
- Visual Studio or Visual Studio Code
- If using Visual Studio Code you will need [C# for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
- k6 (if you want to run the load tests) [k6](https://k6.io/)
    - To install k6 download and run the installer package [download](https://github.com/grafana/k6/releases) 

### Repository

Get the latest code from the [Repo](https://momsurveysite@dev.azure.com/momsurveysite/SurveySiteDemo/_git/SurveySiteDemo) repository.
When cloning the repository, make sure that you don't have spaces in the path to the repo

- In Visual Studio, launch the application using the play button
- In Visual Studio Code, run `dotnet run --launch-profile https`


### Deploy Portal

To deploy the portal to the Azure website go to the [DevOps pipelines](https://dev.azure.com/momsurveysite/SurveySiteDemo/_build) and run the `CD - API Deploy` pipeline. It will deploy the API to the Azure WebApp.

### Network Setup

The application is deployed using Azure. The site is protected by Cloudflare on the front, and then proxied through to a static Azure Web Site for the angular portal and an App Service for the API. The deployed URL is [https://momsurveysitedemo.com/](https://momsurveysitedemo.com/) and the API is [https://api.momsurveysitedemo.com/api/](https://api.momsurveysitedemo.com/api/)

The following is a network diagram that depicts the network

![alt text](./src/assets/images/network-diagram.PNG)

### Configuration

If you need to change the database connection string, go to appsettings.json and change the SurveySiteConnectionString value