namespace Day12.UnitTests;

public static class Constants
{
    public const string SAMPLE_INPUT = @"Sabqponm
abcryxxl
accszExk
acctuvwj
abdefghi";

    public const string PUZZLE_INPUT = @"abcccccaaaaaacccaaaccaaaaaaaacccaaaaaaccccccccccccccccccccccccccccaaaaaaaaaaaaaacacccccccccccccccccccccccccccccccaaaaaaaacccccccccccccccccccccccccccccccccccccccccccccaaaaa
abcccccaaaaaaaacaaaaccaaaaaaccccaaaaaaccccccccccaaacccccccccccccccaaaaaaaaaaaaaaaacccccccccccccccccccccccccccccccaaaaaaaaaccccccaaaccccccccccccccccccccccccccccccccccaaaaaa
abccccaaaaaaaaacaaaaccaaaaaaccccaaaaaaaaccccccccaaaccccccccccccccccaaaaaaaaaaaaaaccccaaaccccccccccccccccccccccccccaaaaaaaaccccacaaaccccccccccccccccaaccccccccccccccccaaaaaa
abcccaaaaaaaaaacaaaccaaaaaaaacccccaaccaaacaaccccaaaaaaaccccccccccccaacaaaaaaaaaccccccaaaaccccccccccccccccccccaaacaaaaaaccccccaaaaaaaacccccccccccccaaaacccccccccccccccaaacaa
abcccaaacaaaccccccccaaaaaaaaaaccccccccaaaaaacaaaaaaaaaaccccccccccccccaaaaaaaaaaccccccaaaaccccccccccccccccaaccaaacaaaaaaacccccaaaaaaaacccccccccccccaaaaccaaaccccccccccccccaa
abcccccccaaaccccccccaaaaaaaaaaccccccaaaaaaaccaaaaaaaaacccccccccccccccaaaacaaaaaaaacccaaaaccccccccccccccccaaaaaaacaaccaaacccccccaaaaacccccccccccccccaaaaaaaaacccccccccccccaa
abcccccccaacccccccccacaaaaaccaccccccaaaaaaacccaaaaaaaccccccaaacccccccaacacaaaaaaaacccccccccccccccccccccccaaaaaaccccccaaaccccccaaaaaccccccccccccjjkkaaaaaaaacccccccccccccccc
abaccccccccccccccccccccaaaacccccccccccaaaaaaccccaaaaaaccccaaaacccccccccccccaaaaaaccccccccccaccaaccccccccccaaaaaaaaccccccccccccaaaaaaccccccccccjjjkkkkkaaaaccccccccaaccccccc
abaccccccccaaaccccccccccaaccccccccccccaacaaacccaaaaaaaccccaaaacccccccccccccaaaaaaccccccccccaaaaacccccccccaaaaaaaaaccccccccccccaccaaacccccccccjjjjkkkkkkkaacccccccccaccccccc
abaacccccccaaaaccccccccccaaaccccccccccaacccccccaaaacaaccccaaaacccccccccccccaaaaaacccccccccccaaaaaccccccccaaaaaaaacccccccaaccccccccccccccccccjjjjoooookkkkkllllllccccaaacccc
abaacccccccaaaaccccccccccaaaaccccccccccccccccccaacaaacaaaccccccccccaaccccccaaacaaccccccccccaaaaaacccccccaaaaaaaccccccccaaaacccccccccccccccccjjjoooooopkkkklllllllccccaacccc
abaccccccccaaacccccccccccaaaacccccccccccccccccccccaaaaaaacccccccccaaaccccccccccccccccccccccaaaaccccccaaaccccaaaccccccccaaaacccccccccccccccccjjooooooopppklppplllllcccaccccc
abacccaaaaaccccccccccccccaaaccccccccccccccccccccccaaaaaaccccccaaaaaaaccccccccccccccccccccccccaaacccccaaacacccaaccccccccaaaaccccccccccccccccjjjooouuuupppppppppplllcccaccccc
abccccaaaaacccccccccccccccccccccccccccccccccccccaaaaaaaaccccccaaaaaaaaaaccaacccccccccccccccccccccccaacaaaaaccccccccccccccccaaacccccaccaccccjjjoouuuuuupppppppppllllccaccccc
abcccaaaaaacccccccccccccaaccccccaaacccccccccccccaaaaaaaaaccccccaaaaaaaaacaaaaccccccccccccccccccccccaaaaaaaaccccccccccccacccaaccccccaaaacccjjjjoouuuuuuupuuuvvpqqlllccaccccc
abcccaaaaaaccccccccccccaaacaacccaaaaacccccccccccaaaaaaaaaaccccccaaaaaaaccaaaacccccccccccccccccccccccaaaaaccccccccccccccaaaaaaacccccaaaaaccijjooouuuxxxuuuuvvvqqqlmccccccccc
abcccaaaaaaccccaacccccccaaaaaccaaaaaccccccccccccaaaaaacaaacccccaaaaaaccccaaaacccccccccccccccccccaaaccaaaaaccccaaaccccccaaaaaaaacccaaaaaaciiiinootuxxxxuuyyyvvqqqmmccccccccc
abcccacaacccccaaacaaccaaaaaacccaaaaaccccccccccccaaaaaacccccccccaaaaaaaccccccccccccaaccacccccccccaaacaaacaaccaaaaaccccccaaaaaaaaaccaaaaaaiiinnnnnttxxxxxyyyyvvqqqmmdddcccccc
abcccaaacaaacccaaaaaccaaaaaaaaccaaaaacccccccccccaaacaaaccccccccaaccaaaccccccccccccaaaaaccccccaaaaaaaaaacccccaaaaaacccccaaaaaaaaaccccaaciiinnnnttttxxxxxyyyyvvqqmmmdddcccccc
abcccaaaaaaacaaaaaacccaacaaaaaccaacccccccccccaaaaaaaaaaaccccccccccccaacccccccccccaaaaacccccccaaaaaaaacccccccaaaaaacccccaaaaaaaaccccccciiinnnnttttxxxxxyyyyvvqqqmmmdddcccccc
SbcccaaaaaaccaaaaaaaaccccaacccccccccccaacccccaaaaaaaaaaccccccccccccccccccccccccccaaaaaaccccccccaaaaaccccccccaaaaacccccaaaaaaaccccccccciiinnntttxxxEzzzzyyvvvqqqmmmdddcccccc
abccaaaaaaaacaacaaaaacccaaccccccccccccaaacccccaaaaaaaaaaaccccccccccccccccccccccccccaaaacccccccaaaaaaccccccccaaaaaccccccacaaaaccccccccciiinnntttxxxxxyyyyyyvvvqqmmmdddcccccc
abcaaaaaaaaaacccaacccccaacccccccccacacaaaccccccaaaaaaaaaacccccccccccccccccccccacccaaccccccccccaaaaaaccccccccccccccccccccaaaaaccccccccciiinnntttxxxxyyyyyyyyvvvqqmmmdddccccc
abcaaaaaaaaaaccaaccaaaaaacccccccccaaaaaaaaaacccaaaaaaaaaacaaccccccccccccaaaaaaaaccccccccccccccaccaaaccccccccccccccccaaacaaacccccccccaaiiinnnttttxxwwyyyyyyyvvvqqmmmdddccccc
abaaccaaacaaaccccccaaaaaaaccccccccaaaaaaaaaacccaaaaaaaacccaaaccccccccccccaaaaaacccccccccccccccccccccccccccccccccccccaaaaaaaaaacccaaaachhhnnnntttsswwyywwwwwvvvrrqkmdddccccc
abaaacaaacccccccccccaaaaaaacccccccccaaaaaacccccaacccaaacccaaaaaaaccccccccaaaaaaccccccccccccccaaccccccccccccccccccccccaaaaaaaaacccaaaaaahhhmmmmmsssswwywwwwwwvrrrrkkdddccccc
abaaaaaaacccccccccccaaaaaaacccccccccaaaaaaccccccaaccccccaaaaaaaaccccccccaaaaaaaaccccccccaaccaaaccccccccccccccccaacccccaaaaaaacccccaaaaahhhhhmmmmssswwwwwrrrrrrrrkkkeeeccccc
abcaaaaaaccccccccccaaaaaacccccccccccaaaaaacccccaaaaccccaaaaaaaaacccccccaaaaaaaaaacccccccaaacaaacccccccccccccacaaaccccaaaaaaccccccaaaaacchhhhhmmmmsswwwwrrrrrrrrrkkkeeeccccc
abaaaaaacccccccccccaaaaaaccccccccccaaaaaaaaccccaaaaccccaaaaaaaaccccccccaaaaaaaaaacaaacccaaaaaaccccccaacccccaaaaaccaccaaaaaaacccccaccaacccchhhhmmmssswwsrrrrrrrkkkkkeeeccccc
abaaaaaaaccccccccaaccccaaccccccccccaaaaaaacccccaaaacccccccaaaaaacccaaccacaaaaaccccaaaccccaaaaaaaaaacaaaccccaaaaaaaaccaaacaaaccccccccccccccchhhhmmssssssrlllkkkkkkkeeecccccc
abaaaaaaaaccccccaaacaacccccccccccccaaaaaaaaccccccccccccccaaaaaaacccaacccccaaaaccccaaaaaaaaaaaaaaaaaaaacccccccaaaaaccccccccaaaacccccccccccccchhgmmmsssssllllkkkkkeeeeeaacccc
abcaaacaaacccccccaaaaaccccccccccccaaaaaaaaaccccccccccccccaaaccaaaaaaaaaacccaaccaaaaaaaaaaaaaaaaacaaaaaaaccccaaaaacccccccaaaaaacccccccccccccccggmmmlssslllllffeeeeeeeaaacccc
abcaaacccccccccaaaaaacccccccaaacaaacaaaaaaacccccccccccccaaaaccccaaaaaaaacccccccaaaaaaaaaaaaaaaccaaaaaaaaccccaacaacccccccaaaaaacccccccccccccccgggmmlllllllfffffeeeeaaaaacccc
abcaaccccccccccaaaaaaaacccccaaaaaaaaaaaaaccccccccccccccccaaaacccccaaaacccccaacccaaaaaaaccccaaaccaaaaaaaacccccccaaccccccccaaaaaaaccccccccccccccggglllllllffffffecacaaacccccc
abcccccccccaaccaacaaaaaccccccaaaaaaaaaaaaccccccaaccaaccaaaaaaccccaaaaaccccaaccccccaaaaaacccaaaccaacaaaccaaaacccccccccccccaaaaaaaccccccccccccccggggllllfffffcccccccaaacccccc
abcccccccaaaaaaccaaacccccccccaaaaaaaaccaaacccccaaaaaaccaaaaacccccaaaaaacccaaaccaaaaaaaaacccccccccccaaaccaaaaacccccccccccaaaaaaaaaccaaccccccccccggggggfffffccccccccccccccccc
abcaaccccaaaaaaccaaccccccccaaaaaaaaaacccaacccccaaaaaccccaaaaaccccacccaaccaaaaccaaaaaccaacccccccccccccccaaaaaacccccccaaacaaaaaaaaaaaaacccccccccccgggggfffaacccccccccccccaccc
abaaaccccaaaaaaccccccccaaacaaaaaaaaaaaaaaaaaaccaaaaaacccaaccacccccccaaaaaaaaaaaaaaaccccccccccccccaaaaccaaaaaacccccccaaaaaaaaaacaaaaaaccccccccccccagggfcaaaccccccccccccaaaaa
abaaaacccaaaaaccccccccaaaacaaacaaacccaaaaaaaacaaaaaaaaccccccccccccccaaaaaaaaaaaaaaacccccccccccccaaaaacccaaaaaccccccccaaaaaacaaaaaaaaccccccccccccccaccccaaacccccccccccccaaaa
abaaaaccccaaaaccccccccaaaacccccaaacccccaaaacccaaaaaaaacccccccccccccccaaaaaaaaaaaaaacccccccccccccaaaaaaccaaaccccccccccaaaaaaaaaaaaaaaaccccccccccccccccccccacccccccccccccaaaa
abaacccccccccccccccccccaaacccccaacccccaaaaaacccccaacccccccccccccccccccccaaaaaaaaacccccccccccccccaaaaaacccccccccccccaaaaaaaaaaaaaaaaaaacccccccccccccccccccccccccccccccaaaaaa";
}