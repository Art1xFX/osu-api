# osu-api
Cross-platform C# library for osu!api

## Using

```c# 
var osuApi = new Osu.Api("your api key");
```

### GetBeatmaps
```c#
var beatmaps = await osuApi.GetBeatmapsAsync();
```
Or 
```c#
var beatmaps = await Osu.Api.GetBeatmapsAsync("your api key");
```

```c#
var beatmaps = await osuApi.GetBeatmapsAsync(u: "Taazar");
```
