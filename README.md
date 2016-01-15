# CtaSharp
A C# client for the Chicago Transit Authority Web API. 

NOTE: This project is not maintained or affiliated with the Chicago Transit Authority (CTA). CtaSharp is a unofficial C# library for the CTA web API provided by the CTA. You will need to obtain an API key from the CTA to access to their API.

Get Route:

Returns all route and train information for the red line

```
CtaTrainTracker trainTracker = new CtaTrainTracker("API_KEY");
Route route = trainTracker.GetRoute(EnumTrainRoute.Red);
```

Get ETA:

Provides estimated time of arrival for upcoming stations based on the run number. This information is not always available.

```
CtaTrainTracker trainTracker = new CtaTrainTracker("API_KEY");
IEnumerable<ETA> arrivalTimes = trainTracker.GetArrivalTimesByRunNumber (RUN_NUMBER_INT)
```

[![Build Status Mono](https://travis-ci.org/SergueiFedorov/CtaSharp.svg?branch=master)](https://travis-ci.org/SergueiFedorov/CtaSharp)
