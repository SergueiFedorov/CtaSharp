# CtaSharp
A C# client for the Chicago Transit Authority

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
