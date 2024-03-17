# HackerNewsServices API

## Overview
This is a web API developed in ASP.net core which internally calls HackerNews web APIs and gets the data. Currently we have consumed only "Story" data - based on requirement. This API will retrieve the details of the best n stories from the Hacker News API, as determined by their score, where n is
specified by the caller to the API.

## **API Name :** 
GetBestStories

## **Parameters :** 
int n {n} where n will be considered as top 'n' best stories to be fetched.

## **Assumptions:** 
If we want to consume any other items from the HackerNews or any other source, we can add respective class libraries.

**Absolute TimeOut :** 5 Minutes

**Idle TimeOut :** 2 Mintues

**Performance :** Very first request will take a bit to implement as data is cached first time. Next time onwards, resposne will be faster as cached data will be used.

## **Scope of Improvement**
1. We add configurable parameters e.g. timeouts, urls, hackerNews APIs etc. For now, everything is hardcoded.
2. Exception handling will be added
3. Logging will be added
4. Will add comments if required in the code
   
