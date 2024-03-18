# HackerNewsServices API

## Overview
This is a web API developed in ASP.net core which internally calls HackerNews web APIs and gets the data. Currently we have consumed only "Story" data - based on requirement. This API will retrieve the details of the best n stories from the Hacker News API, as determined by their score, where n is
specified by the caller to the API.

## **API Name :** 
GetBestStories

## **Parameters :** 
int n {n} where n will be considered as top 'n' best stories to be fetched.

**## How to run an Application:**
Download the project or clone it to local directory.Open and Rebuild the solution in Visual Studio. And click on "Run" - by using Swagger express, visual studio will launch the browser and we can run API through browser. We should give mandatory number to run an API. That number must be in between 1 to 200 - as total bestStories are 200.

## **Assumptions:** 
If we want to consume any other items from the HackerNews or any other source, we can add respective class libraries.

**Absolute TimeOut :** 5 Minutes

**Idle TimeOut :** 2 Mintues

**Performance :** Very first request will take a bit to implement as data is cached first time. Next time onwards, resposne will be faster as cached data will be used.

## **Scope of Improvement**
1. Have not published the code, we an publish and can host on IIS or Azure cloud.
2. We can add configurable parameters e.g. timeouts, urls, hackerNews APIs etc. For now, everything is hardcoded.
3. Can add code level validations.
4. Exception handling will be added.
5. Logging will be added.
6. Need to add comments in the code.
   
