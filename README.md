# BenchmarkMongoElementNameValidator
The purpose of this benchmark was to find which method of the string lookup in the collection of 5 items is the fastest.

Here are the results from my machine:

|                     Method | elementName |     Mean |     Error |    StdDev |
|--------------------------- |------------ |--------- |---------- |---------- |
| IsValidElementNameOriginal |       $code | 39.92 ns | 0.4549 ns | 0.4033 ns |
|    IsValidElementNameArray |       $code | 36.36 ns | 0.6538 ns | 0.5795 ns |
|  IsValidElementNameHashSet |       $code | 37.67 ns | 0.5875 ns | 0.5495 ns |
| IsValidElementNameOriginal |         $db | 28.12 ns | 0.5414 ns | 0.5064 ns |
|    IsValidElementNameArray |         $db | 24.89 ns | 0.3851 ns | 0.3414 ns |
|  IsValidElementNameHashSet |         $db | 36.53 ns | 0.3256 ns | 0.3045 ns |
| IsValidElementNameOriginal |         $id | 39.62 ns | 0.4691 ns | 0.4388 ns |
|    IsValidElementNameArray |         $id | 35.74 ns | 0.2046 ns | 0.1709 ns |
|  IsValidElementNameHashSet |         $id | 38.31 ns | 0.2810 ns | 0.2629 ns |
| IsValidElementNameOriginal |        $ref | 30.77 ns | 0.4165 ns | 0.3896 ns |
|    IsValidElementNameArray |        $ref | 28.02 ns | 0.1563 ns | 0.1220 ns |
|  IsValidElementNameHashSet |        $ref | 37.02 ns | 0.2355 ns | 0.2203 ns |
| IsValidElementNameOriginal |      $scope | 46.13 ns | 0.0940 ns | 0.0879 ns |
|    IsValidElementNameArray |      $scope | 39.71 ns | 0.3720 ns | 0.3106 ns |
|  IsValidElementNameHashSet |      $scope | 39.18 ns | 0.7640 ns | 0.6772 ns |
| IsValidElementNameOriginal | $notInExceptionList | 50.02 ns | 0.3281 ns | 0.3069 ns |
|    IsValidElementNameArray | $notInExceptionList | 44.75 ns | 0.0712 ns | 0.0666 ns |
|  IsValidElementNameHashSet | $notInExceptionList | 43.17 ns | 0.3230 ns | 0.3022 ns |
