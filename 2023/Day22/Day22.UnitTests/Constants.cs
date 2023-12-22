namespace Day22.UnitTests;

public static class Constants
{
    public const string SAMPLE_INPUT = @"1,0,1~1,2,1
0,0,2~2,0,2
0,2,3~2,2,3
0,0,4~0,2,4
2,0,5~2,2,5
0,1,6~2,1,6
1,1,8~1,1,9";

    public const string PUZZLE_INPUT = @"4,2,67~4,5,67
7,2,224~7,2,226
8,3,40~9,3,40
0,4,177~0,7,177
5,6,192~5,8,192
2,0,50~5,0,50
4,1,190~6,1,190
4,0,193~4,1,193
6,5,51~6,5,53
0,4,186~0,8,186
4,5,28~6,5,28
7,3,13~9,3,13
5,0,300~5,3,300
6,0,99~6,2,99
7,2,55~7,5,55
4,1,179~4,2,179
3,2,94~5,2,94
8,7,192~8,7,194
4,5,257~6,5,257
8,4,295~8,6,295
6,6,178~8,6,178
6,8,253~9,8,253
7,6,232~7,9,232
3,3,146~3,4,146
5,1,55~6,1,55
7,1,226~7,1,228
3,5,158~3,7,158
6,0,254~7,0,254
2,4,90~6,4,90
4,8,222~6,8,222
6,7,275~6,7,278
0,2,122~3,2,122
6,9,49~9,9,49
0,4,41~2,4,41
3,2,81~3,5,81
4,0,14~7,0,14
0,0,188~2,0,188
8,5,144~8,8,144
6,8,45~8,8,45
5,0,194~7,0,194
9,5,242~9,8,242
3,7,235~3,8,235
5,1,159~5,2,159
4,7,241~6,7,241
4,1,164~4,5,164
6,3,149~6,3,150
4,8,180~7,8,180
1,5,7~1,7,7
4,4,192~4,6,192
3,5,264~6,5,264
1,3,265~1,5,265
0,7,2~0,8,2
7,0,17~8,0,17
1,0,266~3,0,266
4,0,114~4,1,114
4,7,128~4,9,128
4,2,135~4,4,135
0,2,225~2,2,225
4,7,174~5,7,174
5,0,140~7,0,140
4,4,47~4,7,47
5,6,58~7,6,58
9,8,245~9,9,245
5,1,115~5,3,115
5,0,225~7,0,225
4,3,278~7,3,278
0,6,278~3,6,278
8,1,92~9,1,92
1,8,52~3,8,52
5,1,7~5,2,7
4,7,240~4,9,240
8,1,49~8,4,49
1,1,6~4,1,6
0,5,36~0,7,36
7,3,106~7,5,106
3,0,185~3,0,185
4,8,94~5,8,94
5,4,41~5,4,42
4,5,238~4,7,238
7,6,56~7,7,56
6,4,256~6,5,256
8,1,234~8,2,234
3,5,40~3,8,40
6,8,149~9,8,149
0,1,76~2,1,76
3,2,30~3,4,30
3,4,244~3,6,244
7,1,288~7,3,288
5,9,276~6,9,276
0,6,1~0,6,1
7,6,60~8,6,60
2,2,75~2,4,75
8,3,278~8,3,279
1,5,84~4,5,84
3,1,58~5,1,58
1,5,43~4,5,43
5,5,210~5,7,210
8,6,137~8,9,137
5,3,74~5,6,74
7,0,1~9,0,1
6,4,56~8,4,56
2,9,119~4,9,119
8,5,140~8,7,140
1,3,21~3,3,21
6,6,212~6,8,212
6,1,144~6,1,146
2,3,85~4,3,85
1,9,66~1,9,68
5,4,40~8,4,40
0,3,251~2,3,251
5,0,215~6,0,215
4,7,194~4,7,196
3,6,179~4,6,179
7,6,112~9,6,112
2,9,1~5,9,1
5,1,218~6,1,218
8,6,189~8,8,189
0,4,290~2,4,290
1,4,2~1,7,2
9,3,245~9,5,245
2,3,137~2,5,137
0,5,33~2,5,33
0,0,128~0,2,128
1,3,84~4,3,84
6,1,8~9,1,8
9,2,105~9,5,105
6,4,273~6,6,273
4,7,44~4,9,44
7,0,3~7,0,4
4,9,126~6,9,126
5,5,2~5,6,2
3,4,118~3,6,118
2,8,189~2,9,189
2,6,46~2,9,46
0,5,72~0,7,72
3,5,233~3,7,233
2,3,132~2,5,132
0,9,196~0,9,197
3,3,142~3,3,143
6,4,70~6,6,70
4,0,36~7,0,36
7,3,122~9,3,122
0,8,261~2,8,261
2,6,16~4,6,16
3,0,41~5,0,41
2,6,29~2,7,29
6,9,35~7,9,35
2,7,152~3,7,152
6,6,277~8,6,277
5,3,227~8,3,227
4,5,140~7,5,140
7,4,179~9,4,179
0,7,61~0,7,62
5,3,83~5,4,83
2,3,229~4,3,229
5,0,248~7,0,248
1,4,95~3,4,95
2,0,84~2,2,84
4,4,88~6,4,88
0,1,282~4,1,282
3,6,235~5,6,235
8,1,16~8,3,16
3,8,29~6,8,29
0,8,134~4,8,134
4,6,178~4,7,178
2,3,117~2,6,117
6,8,82~8,8,82
7,0,260~9,0,260
1,3,121~2,3,121
7,1,108~7,3,108
3,5,195~6,5,195
9,3,188~9,3,189
3,1,245~5,1,245
2,8,56~2,9,56
1,7,236~3,7,236
8,3,3~8,6,3
9,5,66~9,7,66
2,1,3~4,1,3
2,7,297~2,8,297
6,8,186~7,8,186
8,5,293~8,7,293
8,4,46~8,6,46
2,2,167~2,4,167
8,1,226~8,4,226
0,0,268~1,0,268
4,4,177~5,4,177
0,6,190~1,6,190
4,6,34~4,8,34
9,5,229~9,8,229
8,9,146~8,9,146
0,4,43~0,4,46
7,3,96~7,3,99
0,0,56~3,0,56
1,3,134~3,3,134
2,2,210~2,5,210
3,7,118~6,7,118
5,2,181~5,3,181
0,3,228~3,3,228
9,2,182~9,5,182
1,4,260~1,7,260
9,7,255~9,9,255
0,5,251~3,5,251
7,6,145~7,8,145
3,8,279~5,8,279
0,0,78~0,1,78
6,2,222~8,2,222
4,6,61~4,8,61
7,6,2~7,9,2
0,5,71~0,5,71
0,2,28~0,5,28
7,0,43~7,0,45
7,6,276~9,6,276
7,1,32~7,4,32
1,5,280~4,5,280
3,2,89~3,3,89
1,3,19~1,5,19
4,5,48~4,7,48
5,6,146~5,6,146
1,2,181~1,4,181
9,6,295~9,9,295
5,2,114~5,4,114
6,9,280~9,9,280
3,4,265~3,6,265
6,6,284~6,8,284
4,6,286~7,6,286
3,3,185~3,4,185
5,1,137~5,3,137
4,7,252~6,7,252
0,0,231~2,0,231
7,2,78~7,4,78
0,3,46~3,3,46
0,1,146~2,1,146
5,2,106~5,3,106
2,5,45~2,5,45
0,0,197~0,1,197
2,7,281~2,9,281
0,6,48~2,6,48
3,1,231~5,1,231
7,3,132~7,5,132
4,6,52~7,6,52
1,3,199~1,4,199
6,5,232~6,7,232
2,7,170~4,7,170
4,1,111~4,3,111
1,0,265~1,2,265
0,7,175~1,7,175
1,9,158~4,9,158
2,6,120~2,9,120
2,6,253~4,6,253
3,6,172~3,8,172
1,4,55~1,4,57
8,0,212~8,0,212
6,1,132~6,3,132
6,3,228~6,4,228
6,4,7~6,6,7
6,4,288~6,7,288
8,6,153~9,6,153
5,3,218~6,3,218
3,2,3~3,4,3
2,1,122~3,1,122
6,6,272~6,8,272
0,1,164~0,4,164
6,5,289~6,5,290
7,9,184~7,9,186
2,7,191~5,7,191
0,7,189~0,7,190
3,0,290~3,1,290
0,3,231~0,4,231
4,4,258~6,4,258
1,1,197~1,3,197
1,7,209~3,7,209
3,4,105~3,7,105
2,5,168~2,7,168
0,9,283~3,9,283
0,8,198~0,9,198
4,5,198~6,5,198
8,3,257~8,5,257
1,8,65~1,9,65
1,4,193~1,6,193
7,4,11~9,4,11
5,5,56~5,5,57
7,0,251~7,2,251
2,4,146~2,6,146
4,4,120~6,4,120
6,1,3~8,1,3
1,3,209~4,3,209
5,4,53~5,6,53
3,2,289~3,2,292
0,5,217~4,5,217
1,8,58~2,8,58
1,8,165~1,8,167
5,4,215~5,7,215
9,2,117~9,2,117
9,1,125~9,1,126
6,6,132~6,8,132
3,8,135~4,8,135
4,5,199~5,5,199
3,7,260~3,8,260
3,6,119~5,6,119
6,3,104~9,3,104
7,7,176~9,7,176
2,5,104~2,8,104
1,7,135~1,9,135
3,3,123~3,5,123
7,7,148~8,7,148
3,2,233~5,2,233
9,6,232~9,9,232
6,0,212~6,3,212
3,7,12~5,7,12
7,6,245~9,6,245
9,7,4~9,9,4
6,2,270~6,4,270
5,6,121~5,6,122
0,3,33~2,3,33
5,1,203~5,3,203
9,5,211~9,5,212
1,8,126~3,8,126
2,4,173~4,4,173
2,1,14~2,3,14
3,0,71~5,0,71
4,3,1~6,3,1
0,6,264~0,8,264
8,9,70~8,9,71
3,7,108~4,7,108
7,9,68~9,9,68
9,4,209~9,7,209
3,0,221~5,0,221
4,2,182~4,2,185
4,1,277~6,1,277
1,4,246~4,4,246
1,2,161~5,2,161
9,6,81~9,8,81
5,1,5~7,1,5
4,4,124~6,4,124
5,7,193~5,9,193
4,7,236~4,8,236
7,5,2~9,5,2
2,4,228~2,6,228
4,4,65~4,6,65
1,9,33~3,9,33
7,4,80~7,5,80
6,7,204~7,7,204
4,6,220~4,8,220
1,2,264~3,2,264
6,5,135~6,7,135
6,3,44~8,3,44
7,1,117~7,4,117
2,8,156~3,8,156
9,0,250~9,2,250
4,8,43~4,9,43
6,7,50~6,8,50
2,2,270~4,2,270
4,7,245~6,7,245
9,7,6~9,7,8
0,6,286~0,8,286
8,3,150~8,5,150
6,8,135~6,9,135
4,4,254~5,4,254
5,7,296~8,7,296
5,0,189~5,1,189
1,5,100~3,5,100
5,2,167~5,5,167
4,5,114~7,5,114
1,4,172~1,6,172
8,1,239~8,2,239
4,2,35~7,2,35
0,3,194~2,3,194
6,3,91~9,3,91
4,1,167~4,3,167
8,5,230~8,7,230
3,5,126~3,7,126
6,5,201~6,7,201
7,5,18~9,5,18
4,1,53~6,1,53
8,1,136~8,3,136
1,2,183~1,5,183
0,5,87~0,8,87
7,7,19~7,9,19
9,2,252~9,3,252
1,0,55~1,2,55
3,0,40~3,3,40
1,9,126~3,9,126
2,3,32~2,6,32
3,1,232~4,1,232
3,6,15~3,8,15
6,9,275~7,9,275
5,2,171~7,2,171
8,1,139~8,3,139
2,2,224~4,2,224
3,3,250~3,6,250
4,0,228~6,0,228
1,4,133~4,4,133
7,6,268~8,6,268
4,5,12~7,5,12
0,2,125~0,4,125
7,8,127~7,8,129
6,0,102~8,0,102
9,7,24~9,8,24
8,0,32~8,3,32
5,9,254~8,9,254
3,2,262~3,5,262
6,6,8~6,9,8
7,8,284~7,9,284
1,4,107~4,4,107
7,7,207~9,7,207
2,3,48~5,3,48
9,4,19~9,7,19
7,7,177~9,7,177
1,7,50~1,9,50
5,6,236~7,6,236
5,6,263~5,8,263
5,1,92~5,3,92
7,5,48~7,6,48
6,8,246~6,9,246
8,1,41~8,4,41
5,1,243~7,1,243
0,2,86~0,5,86
6,6,32~7,6,32
2,1,142~2,4,142
1,0,184~3,0,184
0,3,258~0,5,258
6,9,16~8,9,16
4,4,212~5,4,212
5,9,34~7,9,34
5,1,134~8,1,134
6,4,20~8,4,20
3,8,268~5,8,268
2,6,74~4,6,74
3,6,259~4,6,259
9,5,150~9,8,150
5,7,220~6,7,220
5,6,261~7,6,261
2,7,155~2,9,155
6,3,54~6,3,58
6,6,275~7,6,275
3,6,27~3,9,27
0,1,17~2,1,17
5,4,170~5,4,173
0,4,137~1,4,137
7,6,124~7,8,124
0,3,25~0,5,25
3,2,183~3,5,183
8,6,74~8,8,74
9,6,117~9,6,119
4,2,277~5,2,277
6,4,271~6,6,271
2,4,258~3,4,258
3,5,282~5,5,282
0,2,16~1,2,16
7,7,233~7,7,235
6,5,239~9,5,239
8,0,232~8,3,232
9,6,21~9,7,21
8,6,143~8,8,143
7,6,147~7,7,147
6,3,34~6,5,34
7,3,94~7,5,94
8,6,80~8,7,80
8,3,231~8,6,231
0,7,235~0,7,237
5,3,47~6,3,47
6,1,139~6,1,141
0,1,196~0,4,196
6,0,257~6,0,259
5,4,133~5,6,133
6,3,248~6,4,248
3,0,34~3,3,34
2,0,185~2,0,185
4,4,25~7,4,25
1,4,30~1,7,30
3,8,222~3,8,224
9,8,1~9,9,1
1,5,45~1,5,48
3,8,194~7,8,194
9,0,63~9,1,63
5,5,109~5,6,109
0,9,52~2,9,52
9,8,83~9,9,83
3,4,93~5,4,93
2,5,227~2,7,227
6,5,31~6,5,33
4,3,26~4,5,26
0,1,57~0,3,57
0,3,91~0,5,91
5,3,169~5,5,169
3,4,273~3,7,273
0,0,57~0,0,59
9,0,66~9,2,66
2,3,59~2,5,59
1,1,148~2,1,148
9,1,34~9,3,34
7,2,176~7,4,176
6,0,115~6,2,115
6,1,52~8,1,52
6,3,250~7,3,250
0,7,224~3,7,224
4,8,131~7,8,131
7,4,10~7,6,10
1,0,172~1,2,172
4,3,236~4,4,236
3,3,230~3,5,230
5,3,184~5,3,187
1,9,71~1,9,72
1,3,229~1,3,229
6,4,190~6,5,190
6,9,45~6,9,48
4,1,221~5,1,221
4,9,209~7,9,209
3,1,222~4,1,222
4,0,267~4,3,267
5,8,85~6,8,85
1,1,171~3,1,171
6,5,10~6,7,10
0,2,83~3,2,83
8,0,11~8,3,11
6,0,224~6,2,224
5,0,4~5,2,4
2,1,149~2,3,149
7,3,87~7,5,87
6,7,12~7,7,12
1,5,17~3,5,17
4,6,93~4,9,93
9,0,36~9,0,37
1,3,263~3,3,263
9,1,120~9,3,120
5,1,197~7,1,197
3,9,67~6,9,67
0,0,40~0,2,40
3,6,47~3,6,49
4,3,38~5,3,38
8,5,72~8,8,72
2,6,26~4,6,26
1,2,145~3,2,145
6,4,95~8,4,95
5,5,103~8,5,103
3,1,78~4,1,78
7,6,187~7,6,187
3,0,267~3,0,268
5,5,207~5,8,207
4,7,293~4,7,295
3,2,1~3,5,1
0,9,276~3,9,276
5,1,200~5,3,200
2,3,68~2,3,70
9,2,33~9,3,33
5,2,111~8,2,111
8,7,14~8,9,14
6,0,137~6,2,137
9,3,244~9,5,244
3,5,255~3,8,255
0,4,171~3,4,171
9,7,72~9,9,72
5,1,13~8,1,13
5,8,42~7,8,42
2,5,72~2,8,72
7,8,151~9,8,151
7,0,195~7,2,195
6,1,227~6,1,227
5,8,130~8,8,130
8,1,53~8,4,53
5,5,95~8,5,95
1,5,70~3,5,70
3,2,29~3,4,29
6,7,213~9,7,213
5,1,91~8,1,91
6,2,253~6,4,253
0,2,34~0,2,37
9,8,154~9,9,154
1,8,3~1,9,3
8,1,236~8,2,236
7,3,101~8,3,101
4,1,36~4,3,36
2,7,204~5,7,204
1,1,200~1,4,200
2,0,42~2,2,42
1,5,269~1,7,269
4,1,278~4,1,281
4,1,110~6,1,110
2,7,230~2,9,230
6,3,145~6,4,145
2,5,245~4,5,245
7,6,55~9,6,55
0,0,149~0,2,149
2,7,296~4,7,296
5,3,77~8,3,77
1,2,34~1,5,34
7,9,278~9,9,278
6,2,280~6,3,280
7,1,33~8,1,33
1,3,178~4,3,178
6,8,274~6,9,274
6,6,207~6,9,207
2,7,47~3,7,47
7,2,202~7,5,202
7,6,175~7,9,175
2,3,258~2,3,260
6,2,22~6,5,22
5,7,33~5,9,33
3,8,45~3,8,46
9,3,240~9,6,240
9,1,290~9,1,290
3,4,193~3,6,193
0,5,32~0,7,32
2,7,20~2,9,20
5,7,65~5,9,65
1,7,206~3,7,206
3,6,249~5,6,249
6,2,24~6,5,24
0,6,104~1,6,104
9,1,60~9,3,60
6,7,49~8,7,49
3,7,18~4,7,18
0,6,258~0,7,258
2,3,247~2,5,247
4,9,178~7,9,178
3,4,61~3,7,61
2,0,85~3,0,85
0,4,185~2,4,185
2,7,300~4,7,300
4,8,137~5,8,137
5,7,126~7,7,126
4,6,205~4,7,205
3,1,156~5,1,156
2,7,156~5,7,156
0,5,202~0,7,202
2,7,15~2,9,15
4,0,218~5,0,218
1,9,4~1,9,5
6,7,83~8,7,83
6,2,83~8,2,83
6,6,13~8,6,13
2,4,253~2,5,253
5,9,257~7,9,257
5,5,111~5,7,111
9,7,233~9,8,233
9,3,43~9,5,43
1,2,13~1,5,13
7,2,297~7,5,297
1,4,54~1,6,54
9,4,122~9,4,125
5,6,194~5,6,196
5,7,222~5,7,224
6,8,209~8,8,209
1,3,120~4,3,120
5,1,109~7,1,109
3,1,285~7,1,285
5,5,108~8,5,108
3,9,247~6,9,247
5,5,68~5,9,68
5,3,84~8,3,84
9,0,123~9,2,123
2,8,158~4,8,158
2,1,170~2,2,170
2,5,38~2,7,38
3,1,287~3,4,287
1,1,296~3,1,296
4,1,296~5,1,296
1,7,201~3,7,201
7,9,141~8,9,141
7,3,216~9,3,216
7,7,13~7,8,13
4,5,185~7,5,185
5,1,164~5,3,164
4,6,225~4,7,225
2,3,143~2,5,143
0,2,233~0,5,233
1,4,272~1,7,272
6,0,295~7,0,295
9,2,254~9,4,254
1,3,43~2,3,43
2,4,263~2,5,263
5,7,46~7,7,46
4,0,68~6,0,68
3,9,5~5,9,5
0,7,240~1,7,240
1,5,5~3,5,5
4,5,292~4,7,292
8,5,190~8,5,193
7,0,107~9,0,107
3,3,197~3,5,197
1,4,203~1,6,203
5,4,210~8,4,210
8,2,275~8,5,275
4,6,92~6,6,92
2,0,89~2,0,92
3,7,221~3,9,221
4,5,130~6,5,130
5,0,168~5,2,168
0,3,280~0,6,280
5,3,105~5,5,105
3,7,131~4,7,131
0,1,203~0,1,205
0,5,68~2,5,68
2,5,112~2,7,112
5,0,210~8,0,210
0,7,49~0,9,49
1,1,77~3,1,77
7,7,22~7,7,24
5,1,241~5,3,241
2,1,2~2,2,2
0,1,191~0,1,192
6,4,122~6,6,122
3,2,69~3,5,69
4,5,92~4,5,95
0,2,163~2,2,163
6,2,96~9,2,96
2,4,8~2,5,8
6,8,87~9,8,87
6,4,17~8,4,17
1,4,125~1,6,125
4,5,49~4,5,52
6,3,256~8,3,256
2,8,269~2,8,269
3,3,257~3,5,257
4,2,6~6,2,6
9,1,184~9,2,184
2,3,129~5,3,129
6,4,136~6,6,136
5,0,220~5,2,220
0,2,152~1,2,152
7,6,49~9,6,49
4,5,87~5,5,87
9,3,183~9,5,183
3,7,174~3,9,174
4,2,221~6,2,221
2,1,253~2,3,253
0,4,54~0,7,54
0,8,54~2,8,54
8,1,212~8,4,212
1,7,105~1,8,105
2,4,260~2,5,260
0,4,211~2,4,211
5,1,101~5,4,101
4,0,59~6,0,59
2,1,151~4,1,151
5,6,62~8,6,62
2,5,187~2,8,187
1,0,228~3,0,228
6,2,173~8,2,173
1,2,9~1,5,9
3,6,241~5,6,241
1,1,88~1,2,88
4,0,192~5,0,192
0,2,234~0,2,236
7,6,191~9,6,191
4,1,258~4,3,258
3,3,254~3,5,254
2,3,11~2,6,11
1,6,45~1,8,45
1,5,195~2,5,195
3,1,164~3,3,164
1,9,261~3,9,261
5,7,11~8,7,11
0,2,94~0,4,94
1,3,188~1,6,188
9,5,115~9,7,115
5,4,76~7,4,76
7,7,133~7,9,133
0,8,48~1,8,48
5,5,45~8,5,45
7,4,267~7,7,267
1,2,202~2,2,202
7,3,219~7,5,219
0,9,201~2,9,201
7,1,234~7,3,234
2,3,198~2,6,198
7,5,300~7,7,300
9,2,59~9,5,59
0,0,33~0,2,33
5,8,215~8,8,215
3,4,115~6,4,115
1,5,103~1,7,103
2,5,298~2,7,298
7,1,88~7,4,88
8,7,50~8,7,51
1,3,140~3,3,140
6,1,57~6,2,57
6,6,180~8,6,180
6,9,42~9,9,42
5,8,245~5,9,245
5,9,129~8,9,129
0,2,167~0,5,167
7,0,67~9,0,67
1,3,268~1,5,268
0,3,30~0,5,30
4,7,136~6,7,136
0,4,207~0,4,208
7,7,262~8,7,262
2,9,2~4,9,2
4,0,163~6,0,163
1,3,51~1,5,51
8,8,21~8,9,21
1,0,291~3,0,291
3,6,122~3,8,122
0,4,191~0,4,191
8,4,66~8,6,66
8,4,126~8,7,126
0,3,255~2,3,255
8,5,101~9,5,101
6,1,112~6,3,112
6,6,18~9,6,18
4,5,215~4,7,215
9,6,208~9,8,208
4,5,170~7,5,170
1,3,123~1,5,123
8,2,228~9,2,228
6,6,98~7,6,98
6,4,133~6,6,133
4,3,215~7,3,215
2,2,57~2,4,57
6,4,127~7,4,127
7,6,239~7,6,240
3,9,123~6,9,123
4,8,276~6,8,276
9,3,186~9,3,187
3,0,57~5,0,57
1,3,206~1,4,206
5,0,47~8,0,47
7,0,247~9,0,247
3,7,218~5,7,218
4,0,162~4,1,162
0,7,200~3,7,200
3,8,225~3,8,225
2,7,171~2,8,171
4,5,36~4,8,36
5,3,213~8,3,213
1,1,52~1,3,52
2,8,124~3,8,124
2,3,86~3,3,86
7,0,246~7,2,246
8,8,77~8,8,79
6,0,62~7,0,62
6,1,202~8,1,202
6,7,121~7,7,121
2,9,223~5,9,223
5,4,68~7,4,68
2,1,73~2,4,73
6,9,217~8,9,217
5,3,188~6,3,188
1,9,226~3,9,226
1,4,263~1,8,263
5,4,85~5,5,85
1,1,179~1,3,179
1,0,20~1,1,20
7,9,136~8,9,136
3,6,246~4,6,246
3,2,260~4,2,260
5,1,37~5,4,37
5,8,225~5,8,227
7,7,264~7,8,264
8,6,250~8,9,250
6,6,228~9,6,228
2,7,31~2,9,31
6,2,146~6,3,146
7,7,71~7,7,72
7,0,34~9,0,34
4,6,110~4,7,110
9,5,5~9,5,7
0,3,54~2,3,54
9,9,39~9,9,41
8,7,139~8,9,139
8,0,3~9,0,3
3,1,117~5,1,117
4,4,247~6,4,247
5,1,293~8,1,293
8,4,15~8,6,15
4,3,201~4,5,201
4,0,63~7,0,63
4,5,213~6,5,213
8,5,109~8,7,109
7,1,210~7,3,210
5,3,95~5,4,95
3,0,293~3,0,295
7,2,41~7,4,41
9,1,218~9,3,218
3,1,184~3,1,186
2,0,2~4,0,2
1,0,59~3,0,59
0,4,87~0,4,89
0,7,59~0,9,59
3,2,199~3,5,199
5,8,282~5,9,282
6,0,217~6,2,217
4,3,272~4,5,272
0,9,161~1,9,161
7,6,69~7,7,69
1,6,204~3,6,204
2,1,12~5,1,12
5,6,76~7,6,76
5,1,79~5,4,79
4,5,297~4,9,297
2,4,196~3,4,196
8,0,105~8,0,106
8,4,45~9,4,45
6,5,187~8,5,187
9,4,233~9,6,233
6,1,117~6,3,117
9,5,284~9,7,284
3,3,271~6,3,271
1,1,298~3,1,298
8,9,24~8,9,26
3,0,181~3,2,181
1,7,64~1,9,64
6,2,94~6,4,94
6,3,11~6,5,11
7,2,114~9,2,114
0,1,255~2,1,255
5,2,45~5,4,45
5,4,214~6,4,214
8,5,98~9,5,98
6,7,128~7,7,128
6,3,267~6,5,267
2,6,45~4,6,45
5,6,280~5,7,280
9,6,64~9,8,64
5,9,181~7,9,181
1,2,40~1,4,40
4,5,19~4,5,20
0,1,166~0,2,166
2,1,61~2,3,61
4,3,242~5,3,242
5,3,27~7,3,27
3,4,149~3,4,151
0,8,5~0,9,5
2,5,184~4,5,184
1,1,266~1,2,266
5,4,26~8,4,26
4,7,173~6,7,173
6,2,289~9,2,289
5,6,115~7,6,115
1,4,288~4,4,288
3,3,238~5,3,238
8,4,269~8,6,269
1,4,22~3,4,22
5,5,43~5,7,43
2,5,115~3,5,115
3,6,227~6,6,227
6,9,243~8,9,243
1,7,265~2,7,265
7,4,8~7,7,8
5,0,157~5,1,157
0,4,261~0,5,261
1,6,289~4,6,289
4,4,144~7,4,144
0,6,135~0,9,135
1,1,165~1,3,165
7,0,208~7,2,208
5,0,197~7,0,197
7,3,29~7,6,29
2,3,250~2,5,250
6,1,16~6,1,17
6,0,292~6,3,292
3,2,80~7,2,80
6,5,204~7,5,204
1,6,273~1,9,273
7,0,199~7,2,199
6,2,52~9,2,52
7,0,257~8,0,257
6,1,221~7,1,221
9,3,57~9,6,57
0,1,150~0,1,152
2,7,188~3,7,188
0,1,202~3,1,202
6,6,183~7,6,183
2,6,142~4,6,142
1,5,169~3,5,169
6,6,94~6,6,96
4,1,11~7,1,11
7,1,214~9,1,214
0,1,183~2,1,183
3,5,127~3,5,128
2,0,292~3,0,292
2,2,166~2,5,166
6,7,282~9,7,282
1,3,27~3,3,27
8,6,69~8,8,69
8,3,217~8,5,217
7,4,151~7,4,153
2,3,65~2,5,65
7,9,282~8,9,282
6,4,211~6,5,211
4,7,94~6,7,94
2,6,262~2,8,262
5,4,259~5,6,259
4,3,275~4,5,275
5,7,125~8,7,125
3,7,197~5,7,197
8,1,217~8,2,217
5,7,279~7,7,279
8,6,297~8,8,297
4,6,177~4,9,177
3,2,236~6,2,236
2,3,63~5,3,63
5,3,64~7,3,64
0,4,204~0,5,204
2,8,264~2,8,268
4,3,137~4,5,137
1,6,62~1,7,62
4,5,89~4,7,89
1,4,135~1,5,135
1,7,239~3,7,239
1,4,28~4,4,28
1,4,1~1,6,1
2,2,16~2,2,17
6,7,246~6,7,248
9,4,121~9,7,121
9,3,37~9,5,37
7,7,294~9,7,294
0,3,290~3,3,290
1,2,168~1,2,170
7,7,29~8,7,29
4,2,120~6,2,120
8,6,63~9,6,63
8,5,114~8,8,114
7,9,211~7,9,214
0,2,175~2,2,175
3,0,115~5,0,115
8,7,21~8,7,23
9,3,127~9,6,127
7,0,172~7,3,172
1,7,5~3,7,5
1,5,173~4,5,173
4,4,233~4,7,233
5,3,81~7,3,81
3,0,227~3,3,227
8,3,94~8,3,97
2,3,180~5,3,180
8,5,26~8,7,26
3,0,188~6,0,188
5,3,15~5,6,15
5,4,250~5,7,250
2,6,13~2,8,13
3,6,60~5,6,60
3,6,63~3,7,63
3,1,2~4,1,2
3,0,153~3,2,153
4,2,297~6,2,297
3,4,188~3,5,188
5,4,20~5,6,20
7,4,143~7,5,143
1,2,37~1,4,37
4,2,176~4,4,176
2,4,174~2,4,175
8,3,34~8,5,34
1,1,180~3,1,180
4,1,230~4,4,230
1,2,271~2,2,271
7,1,223~7,1,225
5,4,206~8,4,206
3,3,126~5,3,126
3,9,263~3,9,266
6,3,50~6,5,50
8,1,225~8,3,225
2,2,128~2,5,128
1,6,127~1,7,127
0,4,232~0,7,232
2,1,39~4,1,39
3,8,37~5,8,37
9,2,291~9,4,291
1,6,130~1,6,131
1,5,102~4,5,102
1,8,42~4,8,42
2,8,113~2,9,113
5,3,71~5,5,71
2,2,125~2,5,125
3,4,18~5,4,18
2,5,149~2,7,149
4,4,256~4,6,256
6,6,5~7,6,5
1,7,61~1,8,61
8,4,188~8,6,188
9,6,83~9,7,83
5,5,291~5,7,291
2,2,32~3,2,32
5,0,274~5,3,274
5,0,3~5,3,3
0,8,93~0,9,93
2,7,270~4,7,270
2,8,190~2,8,190
3,8,3~5,8,3
8,3,207~8,5,207
5,4,251~5,4,251
7,9,67~8,9,67
8,2,176~8,2,177
3,2,265~5,2,265
6,4,58~6,5,58
5,9,132~5,9,132
3,4,276~3,5,276
3,7,301~3,9,301
1,3,293~1,5,293
1,8,164~1,9,164
7,4,65~7,6,65
2,2,123~3,2,123
2,1,119~2,3,119
0,2,178~0,4,178
8,4,76~8,6,76
0,8,128~2,8,128
3,8,62~5,8,62
6,5,188~6,7,188
3,4,124~3,5,124
0,1,184~1,1,184
5,3,118~5,4,118
0,6,172~0,8,172
7,9,244~7,9,246
6,2,299~6,5,299
4,8,31~6,8,31
5,7,259~7,7,259
4,2,295~7,2,295
5,7,175~6,7,175
3,1,5~3,3,5
6,6,229~8,6,229
1,1,85~1,3,85
2,4,98~2,5,98
2,9,116~4,9,116
5,9,70~6,9,70
2,6,57~2,9,57
3,9,268~5,9,268
3,8,84~6,8,84
0,3,291~2,3,291
4,6,64~4,9,64
5,8,10~8,8,10
1,7,279~3,7,279
4,2,186~4,5,186
3,6,42~6,6,42
2,0,86~2,0,86
3,5,278~5,5,278
4,0,66~6,0,66
3,6,85~3,8,85
3,4,23~3,7,23
1,1,124~4,1,124
2,6,111~2,8,111
7,5,64~7,7,64
5,9,128~7,9,128
2,5,151~2,6,151
9,6,70~9,9,70
7,6,185~7,8,185
3,9,184~6,9,184
4,3,257~6,3,257
0,2,191~0,3,191
6,7,77~9,7,77
6,3,279~7,3,279
7,7,66~7,9,66
4,7,15~4,8,15
2,7,107~2,7,108
7,6,242~7,9,242
2,7,18~2,9,18
1,5,55~1,7,55
8,4,97~8,4,100
7,5,173~7,6,173
5,6,290~8,6,290
5,6,40~5,8,40
1,8,1~1,8,2
2,1,230~2,1,232
5,7,243~5,9,243
3,7,257~5,7,257
2,3,98~5,3,98
8,5,142~8,8,142
1,5,16~4,5,16
6,0,12~9,0,12
0,6,51~2,6,51
4,3,138~4,4,138
0,8,274~2,8,274
2,1,228~2,2,228
1,5,66~3,5,66
7,1,231~8,1,231
7,9,38~9,9,38
0,6,283~0,7,283
1,0,160~5,0,160
5,1,136~7,1,136
8,6,247~8,9,247
5,6,182~7,6,182
9,7,79~9,9,79
9,4,236~9,6,236
1,6,259~1,9,259
6,9,144~9,9,144
1,7,268~3,7,268
2,6,223~5,6,223
6,2,268~6,5,268
0,4,24~1,4,24
6,2,274~6,3,274
7,0,40~9,0,40
8,6,20~8,8,20
8,4,27~8,4,27
1,2,164~1,3,164
4,6,267~4,9,267
5,0,49~6,0,49
2,5,139~2,6,139
7,2,205~8,2,205
1,3,10~1,5,10
5,8,249~8,8,249
6,2,273~8,2,273
5,6,46~5,6,48
5,3,166~5,7,166
4,2,37~4,5,37
4,1,240~4,3,240
3,6,275~5,6,275
0,0,198~1,0,198
7,3,30~9,3,30
3,5,116~3,7,116
0,1,201~2,1,201
5,8,97~7,8,97
6,8,98~7,8,98
1,1,144~4,1,144
3,3,24~3,4,24
6,5,127~6,7,127
2,0,295~2,2,295
8,6,154~8,8,154
9,6,180~9,8,180
0,4,29~0,6,29
0,8,88~0,8,91
0,4,170~0,6,170
3,9,122~6,9,122
6,0,38~6,0,38
7,8,147~7,9,147
8,2,43~9,2,43
2,4,36~2,5,36
5,3,130~7,3,130
0,9,58~2,9,58
8,3,86~8,4,86
0,6,256~2,6,256
1,5,194~1,6,194
9,2,124~9,2,126
0,9,163~0,9,165
3,3,64~3,4,64
0,2,129~2,2,129
2,5,190~4,5,190
8,7,178~8,7,180
0,6,193~0,9,193
7,4,203~8,4,203
4,4,103~4,5,103
5,2,55~5,4,55
4,5,31~4,7,31
9,5,107~9,5,111
8,9,251~8,9,252
4,3,15~4,5,15
1,9,8~1,9,10
4,7,181~4,7,182
0,1,188~0,4,188
4,1,192~4,3,192
0,0,30~0,2,30
6,4,148~8,4,148
2,7,276~2,8,276
4,5,265~4,8,265
4,6,122~4,8,122
0,5,21~2,5,21
7,1,289~9,1,289
6,6,73~6,8,73
6,4,291~6,6,291
6,3,52~6,3,53
4,6,144~7,6,144";
}
