# CtaSharp
A C# client for the Chicago Transit Authority

Get Route:

```
CtaTrainTracker trainTracker = new CtaTrainTracker("API_KEY");

//Returns all route and train information for the red line
Route route = trainTracker.GetRoute(EnumTrainRoute.Red);
```

[![Build Status Mono](https://travis-ci.org/SergueiFedorov/CtaSharp.svg?branch=master)](https://travis-ci.org/SergueiFedorov/CtaSharp)
