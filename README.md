# dgc-lib-dotnet
C# /.NET implementation of the [Digital Green Certificate Schema](https://github.com/ehn-digital-green-development/ehn-dgc-schema) in order the read an [EU Digital Green Certificate](https://github.com/eu-digital-green-certificates).

The purpose of this library is to allow deserializing a json representation of the Digital Green Certificate to a c# POCO and vice versa.

Initially the library used System.Text.Json, but currently setting required properties can only be done for .net5 projects which would severly limit the range of consuming applications.
Therefor Newtonsoft.Json was used which provides the necessary Elements and proper integration with DataAnnotations at the cost of bringing more dependencies into the solution.

As the DGC schema is still subject for change this implementation might already be outdated at the time of reading.