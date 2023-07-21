﻿using Newtonsoft.Json;

namespace LeetCode.Trie
{
    public class _472_Concatenated_Words
    {
        /// <summary>
        /// https://leetcode.com/problems/concatenated-words/description/
        /// </summary>
        public static void Test()
        {
            Console.WriteLine(JsonConvert.SerializeObject(FindAllConcatenatedWordsInADict(new[] { "cat", "cats", "catsdogcats", "dog", "dogcatsdog", "hippopotamuses", "rat", "ratcatdogcat" })));
            Console.WriteLine(JsonConvert.SerializeObject(FindAllConcatenatedWordsInADict(new[] { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa", "aaaaaaaaaaa", "aaaaaaaaaaaa", "aaaaaaaaaaaaa", "aaaaaaaaaaaaaa", "aaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaz", "b", "bb", "bbb", "bbbb", "bbbbb", "bbbbbb", "bbbbbbb", "bbbbbbbb", "bbbbbbbbb", "bbbbbbbbbb", "bbbbbbbbbbb", "bbbbbbbbbbbb", "bbbbbbbbbbbbb", "bbbbbbbbbbbbbb", "bbbbbbbbbbbbbbb", "bbbbbbbbbbbbbbbb", "bbbbbbbbbbbbbbbbb", "bbbbbbbbbbbbbbbbbb", "bbbbbbbbbbbbbbbbbbb", "bbbbbbbbbbbbbbbbbbbb", "bbbbbbbbbbbbbbbbbbbbb", "bbbbbbbbbbbbbbbbbbbbbb", "bbbbbbbbbbbbbbbbbbbbbbb", "bbbbbbbbbbbbbbbbbbbbbbbb", "bbbbbbbbbbbbbbbbbbbbbbbbb", "bbbbbbbbbbbbbbbbbbbbbbbbbb", "bbbbbbbbbbbbbbbbbbbbbbbbbbb", "bbbbbbbbbbbbbbbbbbbbbbbbbbbb", "bbbbbbbbbbbbbbbbbbbbbbbbbbbbb", "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbb", "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbz", "c", "cc", "ccc", "cccc", "ccccc", "cccccc", "ccccccc", "cccccccc", "ccccccccc", "cccccccccc", "ccccccccccc", "cccccccccccc", "ccccccccccccc", "cccccccccccccc", "ccccccccccccccc", "cccccccccccccccc", "ccccccccccccccccc", "cccccccccccccccccc", "ccccccccccccccccccc", "cccccccccccccccccccc", "ccccccccccccccccccccc", "cccccccccccccccccccccc", "ccccccccccccccccccccccc", "cccccccccccccccccccccccc", "ccccccccccccccccccccccccc", "cccccccccccccccccccccccccc", "ccccccccccccccccccccccccccc", "cccccccccccccccccccccccccccc", "ccccccccccccccccccccccccccccc", "cccccccccccccccccccccccccccccc", "cccccccccccccccccccccccccccccz", "d", "dd", "ddd", "dddd", "ddddd", "dddddd", "ddddddd", "dddddddd", "ddddddddd", "dddddddddd", "ddddddddddd", "dddddddddddd", "ddddddddddddd", "dddddddddddddd", "ddddddddddddddd", "dddddddddddddddd", "ddddddddddddddddd", "dddddddddddddddddd", "ddddddddddddddddddd", "dddddddddddddddddddd", "ddddddddddddddddddddd", "dddddddddddddddddddddd", "ddddddddddddddddddddddd", "dddddddddddddddddddddddd", "ddddddddddddddddddddddddd", "dddddddddddddddddddddddddd", "ddddddddddddddddddddddddddd", "dddddddddddddddddddddddddddd", "ddddddddddddddddddddddddddddd", "dddddddddddddddddddddddddddddd", "dddddddddddddddddddddddddddddz", "e", "ee", "eee", "eeee", "eeeee", "eeeeee", "eeeeeee", "eeeeeeee", "eeeeeeeee", "eeeeeeeeee", "eeeeeeeeeee", "eeeeeeeeeeee", "eeeeeeeeeeeee", "eeeeeeeeeeeeee", "eeeeeeeeeeeeeee", "eeeeeeeeeeeeeeee", "eeeeeeeeeeeeeeeee", "eeeeeeeeeeeeeeeeee", "eeeeeeeeeeeeeeeeeee", "eeeeeeeeeeeeeeeeeeee", "eeeeeeeeeeeeeeeeeeeee", "eeeeeeeeeeeeeeeeeeeeee", "eeeeeeeeeeeeeeeeeeeeeee", "eeeeeeeeeeeeeeeeeeeeeeee", "eeeeeeeeeeeeeeeeeeeeeeeee", "eeeeeeeeeeeeeeeeeeeeeeeeee", "eeeeeeeeeeeeeeeeeeeeeeeeeee", "eeeeeeeeeeeeeeeeeeeeeeeeeeee", "eeeeeeeeeeeeeeeeeeeeeeeeeeeee", "eeeeeeeeeeeeeeeeeeeeeeeeeeeeee", "eeeeeeeeeeeeeeeeeeeeeeeeeeeeez", "f", "ff", "fff", "ffff", "fffff", "ffffff", "fffffff", "ffffffff", "fffffffff", "ffffffffff", "fffffffffff", "ffffffffffff", "fffffffffffff", "ffffffffffffff", "fffffffffffffff", "ffffffffffffffff", "fffffffffffffffff", "ffffffffffffffffff", "fffffffffffffffffff", "ffffffffffffffffffff", "fffffffffffffffffffff", "ffffffffffffffffffffff", "fffffffffffffffffffffff", "ffffffffffffffffffffffff", "fffffffffffffffffffffffff", "ffffffffffffffffffffffffff", "fffffffffffffffffffffffffff", "ffffffffffffffffffffffffffff", "fffffffffffffffffffffffffffff", "ffffffffffffffffffffffffffffff", "fffffffffffffffffffffffffffffz", "g", "gg", "ggg", "gggg", "ggggg", "gggggg", "ggggggg", "gggggggg", "ggggggggg", "gggggggggg", "ggggggggggg", "gggggggggggg", "ggggggggggggg", "gggggggggggggg", "ggggggggggggggg", "gggggggggggggggg", "ggggggggggggggggg", "gggggggggggggggggg", "ggggggggggggggggggg", "gggggggggggggggggggg", "ggggggggggggggggggggg", "gggggggggggggggggggggg", "ggggggggggggggggggggggg", "gggggggggggggggggggggggg", "ggggggggggggggggggggggggg", "gggggggggggggggggggggggggg", "ggggggggggggggggggggggggggg", "gggggggggggggggggggggggggggg", "ggggggggggggggggggggggggggggg", "gggggggggggggggggggggggggggggg", "gggggggggggggggggggggggggggggz", "h", "hh", "hhh", "hhhh", "hhhhh", "hhhhhh", "hhhhhhh", "hhhhhhhh", "hhhhhhhhh", "hhhhhhhhhh", "hhhhhhhhhhh", "hhhhhhhhhhhh", "hhhhhhhhhhhhh", "hhhhhhhhhhhhhh", "hhhhhhhhhhhhhhh", "hhhhhhhhhhhhhhhh", "hhhhhhhhhhhhhhhhh", "hhhhhhhhhhhhhhhhhh", "hhhhhhhhhhhhhhhhhhh", "hhhhhhhhhhhhhhhhhhhh", "hhhhhhhhhhhhhhhhhhhhh", "hhhhhhhhhhhhhhhhhhhhhh", "hhhhhhhhhhhhhhhhhhhhhhh", "hhhhhhhhhhhhhhhhhhhhhhhh", "hhhhhhhhhhhhhhhhhhhhhhhhh", "hhhhhhhhhhhhhhhhhhhhhhhhhh", "hhhhhhhhhhhhhhhhhhhhhhhhhhh", "hhhhhhhhhhhhhhhhhhhhhhhhhhhh", "hhhhhhhhhhhhhhhhhhhhhhhhhhhhh", "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhh", "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhz", "i", "ii", "iii", "iiii", "iiiii", "iiiiii", "iiiiiii", "iiiiiiii", "iiiiiiiii", "iiiiiiiiii", "iiiiiiiiiii", "iiiiiiiiiiii", "iiiiiiiiiiiii", "iiiiiiiiiiiiii", "iiiiiiiiiiiiiii", "iiiiiiiiiiiiiiii", "iiiiiiiiiiiiiiiii", "iiiiiiiiiiiiiiiiii", "iiiiiiiiiiiiiiiiiii", "iiiiiiiiiiiiiiiiiiii", "iiiiiiiiiiiiiiiiiiiii", "iiiiiiiiiiiiiiiiiiiiii", "iiiiiiiiiiiiiiiiiiiiiii", "iiiiiiiiiiiiiiiiiiiiiiii", "iiiiiiiiiiiiiiiiiiiiiiiii", "iiiiiiiiiiiiiiiiiiiiiiiiii", "iiiiiiiiiiiiiiiiiiiiiiiiiii", "iiiiiiiiiiiiiiiiiiiiiiiiiiii", "iiiiiiiiiiiiiiiiiiiiiiiiiiiii", "iiiiiiiiiiiiiiiiiiiiiiiiiiiiii", "iiiiiiiiiiiiiiiiiiiiiiiiiiiiiz", "j", "jj", "jjj", "jjjj", "jjjjj", "jjjjjj", "jjjjjjj", "jjjjjjjj", "jjjjjjjjj", "jjjjjjjjjj", "jjjjjjjjjjj", "jjjjjjjjjjjj", "jjjjjjjjjjjjj", "jjjjjjjjjjjjjj", "jjjjjjjjjjjjjjj", "jjjjjjjjjjjjjjjj", "jjjjjjjjjjjjjjjjj", "jjjjjjjjjjjjjjjjjj", "jjjjjjjjjjjjjjjjjjj", "jjjjjjjjjjjjjjjjjjjj", "jjjjjjjjjjjjjjjjjjjjj", "jjjjjjjjjjjjjjjjjjjjjj", "jjjjjjjjjjjjjjjjjjjjjjj", "jjjjjjjjjjjjjjjjjjjjjjjj", "jjjjjjjjjjjjjjjjjjjjjjjjj", "jjjjjjjjjjjjjjjjjjjjjjjjjj", "jjjjjjjjjjjjjjjjjjjjjjjjjjj", "jjjjjjjjjjjjjjjjjjjjjjjjjjjj", "jjjjjjjjjjjjjjjjjjjjjjjjjjjjj", "jjjjjjjjjjjjjjjjjjjjjjjjjjjjjj", "jjjjjjjjjjjjjjjjjjjjjjjjjjjjjz", "k", "kk", "kkk", "kkkk", "kkkkk", "kkkkkk", "kkkkkkk", "kkkkkkkk", "kkkkkkkkk", "kkkkkkkkkk", "kkkkkkkkkkk", "kkkkkkkkkkkk", "kkkkkkkkkkkkk", "kkkkkkkkkkkkkk", "kkkkkkkkkkkkkkk", "kkkkkkkkkkkkkkkk", "kkkkkkkkkkkkkkkkk", "kkkkkkkkkkkkkkkkkk", "kkkkkkkkkkkkkkkkkkk", "kkkkkkkkkkkkkkkkkkkk", "kkkkkkkkkkkkkkkkkkkkk", "kkkkkkkkkkkkkkkkkkkkkk", "kkkkkkkkkkkkkkkkkkkkkkk", "kkkkkkkkkkkkkkkkkkkkkkkk", "kkkkkkkkkkkkkkkkkkkkkkkkk", "kkkkkkkkkkkkkkkkkkkkkkkkkk", "kkkkkkkkkkkkkkkkkkkkkkkkkkk", "kkkkkkkkkkkkkkkkkkkkkkkkkkkk", "kkkkkkkkkkkkkkkkkkkkkkkkkkkkk", "kkkkkkkkkkkkkkkkkkkkkkkkkkkkkk", "kkkkkkkkkkkkkkkkkkkkkkkkkkkkkz", "l", "ll", "lll", "llll", "lllll", "llllll", "lllllll", "llllllll", "lllllllll", "llllllllll", "lllllllllll", "llllllllllll", "lllllllllllll", "llllllllllllll", "lllllllllllllll", "llllllllllllllll", "lllllllllllllllll", "llllllllllllllllll", "lllllllllllllllllll", "llllllllllllllllllll", "lllllllllllllllllllll", "llllllllllllllllllllll", "lllllllllllllllllllllll", "llllllllllllllllllllllll", "lllllllllllllllllllllllll", "llllllllllllllllllllllllll", "lllllllllllllllllllllllllll", "llllllllllllllllllllllllllll", "lllllllllllllllllllllllllllll", "llllllllllllllllllllllllllllll", "lllllllllllllllllllllllllllllz", "m", "mm", "mmm", "mmmm", "mmmmm", "mmmmmm", "mmmmmmm", "mmmmmmmm", "mmmmmmmmm", "mmmmmmmmmm", "mmmmmmmmmmm", "mmmmmmmmmmmm", "mmmmmmmmmmmmm", "mmmmmmmmmmmmmm", "mmmmmmmmmmmmmmm", "mmmmmmmmmmmmmmmm", "mmmmmmmmmmmmmmmmm", "mmmmmmmmmmmmmmmmmm", "mmmmmmmmmmmmmmmmmmm", "mmmmmmmmmmmmmmmmmmmm", "mmmmmmmmmmmmmmmmmmmmm", "mmmmmmmmmmmmmmmmmmmmmm", "mmmmmmmmmmmmmmmmmmmmmmm", "mmmmmmmmmmmmmmmmmmmmmmmm", "mmmmmmmmmmmmmmmmmmmmmmmmm", "mmmmmmmmmmmmmmmmmmmmmmmmmm", "mmmmmmmmmmmmmmmmmmmmmmmmmmm", "mmmmmmmmmmmmmmmmmmmmmmmmmmmm", "mmmmmmmmmmmmmmmmmmmmmmmmmmmmm", "mmmmmmmmmmmmmmmmmmmmmmmmmmmmmm", "mmmmmmmmmmmmmmmmmmmmmmmmmmmmmz", "n", "nn", "nnn", "nnnn", "nnnnn", "nnnnnn", "nnnnnnn", "nnnnnnnn", "nnnnnnnnn", "nnnnnnnnnn", "nnnnnnnnnnn", "nnnnnnnnnnnn", "nnnnnnnnnnnnn", "nnnnnnnnnnnnnn", "nnnnnnnnnnnnnnn", "nnnnnnnnnnnnnnnn", "nnnnnnnnnnnnnnnnn", "nnnnnnnnnnnnnnnnnn", "nnnnnnnnnnnnnnnnnnn", "nnnnnnnnnnnnnnnnnnnn", "nnnnnnnnnnnnnnnnnnnnn", "nnnnnnnnnnnnnnnnnnnnnn", "nnnnnnnnnnnnnnnnnnnnnnn", "nnnnnnnnnnnnnnnnnnnnnnnn", "nnnnnnnnnnnnnnnnnnnnnnnnn", "nnnnnnnnnnnnnnnnnnnnnnnnnn", "nnnnnnnnnnnnnnnnnnnnnnnnnnn", "nnnnnnnnnnnnnnnnnnnnnnnnnnnn", "nnnnnnnnnnnnnnnnnnnnnnnnnnnnn", "nnnnnnnnnnnnnnnnnnnnnnnnnnnnnn", "nnnnnnnnnnnnnnnnnnnnnnnnnnnnnz", "o", "oo", "ooo", "oooo", "ooooo", "oooooo", "ooooooo", "oooooooo", "ooooooooo", "oooooooooo", "ooooooooooo", "oooooooooooo", "ooooooooooooo", "oooooooooooooo", "ooooooooooooooo", "oooooooooooooooo", "ooooooooooooooooo", "oooooooooooooooooo", "ooooooooooooooooooo", "oooooooooooooooooooo", "ooooooooooooooooooooo", "oooooooooooooooooooooo", "ooooooooooooooooooooooo", "oooooooooooooooooooooooo", "ooooooooooooooooooooooooo", "oooooooooooooooooooooooooo", "ooooooooooooooooooooooooooo", "oooooooooooooooooooooooooooo", "ooooooooooooooooooooooooooooo", "oooooooooooooooooooooooooooooo", "oooooooooooooooooooooooooooooz", "p", "pp", "ppp", "pppp", "ppppp", "pppppp", "ppppppp", "pppppppp", "ppppppppp", "pppppppppp", "ppppppppppp", "pppppppppppp", "ppppppppppppp", "pppppppppppppp", "ppppppppppppppp", "pppppppppppppppp", "ppppppppppppppppp", "pppppppppppppppppp", "ppppppppppppppppppp", "pppppppppppppppppppp", "ppppppppppppppppppppp", "pppppppppppppppppppppp", "ppppppppppppppppppppppp", "pppppppppppppppppppppppp", "ppppppppppppppppppppppppp", "pppppppppppppppppppppppppp", "ppppppppppppppppppppppppppp", "pppppppppppppppppppppppppppp", "ppppppppppppppppppppppppppppp", "pppppppppppppppppppppppppppppp", "pppppppppppppppppppppppppppppz", "q", "qq", "qqq", "qqqq", "qqqqq", "qqqqqq", "qqqqqqq", "qqqqqqqq", "qqqqqqqqq", "qqqqqqqqqq", "qqqqqqqqqqq", "qqqqqqqqqqqq", "qqqqqqqqqqqqq", "qqqqqqqqqqqqqq", "qqqqqqqqqqqqqqq", "qqqqqqqqqqqqqqqq", "qqqqqqqqqqqqqqqqq", "qqqqqqqqqqqqqqqqqq", "qqqqqqqqqqqqqqqqqqq", "qqqqqqqqqqqqqqqqqqqq", "qqqqqqqqqqqqqqqqqqqqq", "qqqqqqqqqqqqqqqqqqqqqq", "qqqqqqqqqqqqqqqqqqqqqqq", "qqqqqqqqqqqqqqqqqqqqqqqq", "qqqqqqqqqqqqqqqqqqqqqqqqq", "qqqqqqqqqqqqqqqqqqqqqqqqqq", "qqqqqqqqqqqqqqqqqqqqqqqqqqq", "qqqqqqqqqqqqqqqqqqqqqqqqqqqq", "qqqqqqqqqqqqqqqqqqqqqqqqqqqqq", "qqqqqqqqqqqqqqqqqqqqqqqqqqqqqq", "qqqqqqqqqqqqqqqqqqqqqqqqqqqqqz", "r", "rr", "rrr", "rrrr", "rrrrr", "rrrrrr", "rrrrrrr", "rrrrrrrr", "rrrrrrrrr", "rrrrrrrrrr", "rrrrrrrrrrr", "rrrrrrrrrrrr", "rrrrrrrrrrrrr", "rrrrrrrrrrrrrr", "rrrrrrrrrrrrrrr", "rrrrrrrrrrrrrrrr", "rrrrrrrrrrrrrrrrr", "rrrrrrrrrrrrrrrrrr", "rrrrrrrrrrrrrrrrrrr", "rrrrrrrrrrrrrrrrrrrr", "rrrrrrrrrrrrrrrrrrrrr", "rrrrrrrrrrrrrrrrrrrrrr", "rrrrrrrrrrrrrrrrrrrrrrr", "rrrrrrrrrrrrrrrrrrrrrrrr", "rrrrrrrrrrrrrrrrrrrrrrrrr", "rrrrrrrrrrrrrrrrrrrrrrrrrr", "rrrrrrrrrrrrrrrrrrrrrrrrrrr", "rrrrrrrrrrrrrrrrrrrrrrrrrrrr", "rrrrrrrrrrrrrrrrrrrrrrrrrrrrr", "rrrrrrrrrrrrrrrrrrrrrrrrrrrrrr", "rrrrrrrrrrrrrrrrrrrrrrrrrrrrrz", "s", "ss", "sss", "ssss", "sssss", "ssssss", "sssssss", "ssssssss", "sssssssss", "ssssssssss", "sssssssssss", "ssssssssssss", "sssssssssssss", "ssssssssssssss", "sssssssssssssss", "ssssssssssssssss", "sssssssssssssssss", "ssssssssssssssssss", "sssssssssssssssssss", "ssssssssssssssssssss", "sssssssssssssssssssss", "ssssssssssssssssssssss", "sssssssssssssssssssssss", "ssssssssssssssssssssssss", "sssssssssssssssssssssssss", "ssssssssssssssssssssssssss", "sssssssssssssssssssssssssss", "ssssssssssssssssssssssssssss", "sssssssssssssssssssssssssssss", "ssssssssssssssssssssssssssssss", "sssssssssssssssssssssssssssssz", "t", "tt", "ttt", "tttt", "ttttt", "tttttt", "ttttttt", "tttttttt", "ttttttttt", "tttttttttt", "ttttttttttt", "tttttttttttt", "ttttttttttttt", "tttttttttttttt", "ttttttttttttttt", "tttttttttttttttt", "ttttttttttttttttt", "tttttttttttttttttt", "ttttttttttttttttttt", "tttttttttttttttttttt", "ttttttttttttttttttttt", "tttttttttttttttttttttt", "ttttttttttttttttttttttt", "tttttttttttttttttttttttt", "ttttttttttttttttttttttttt", "tttttttttttttttttttttttttt", "ttttttttttttttttttttttttttt", "tttttttttttttttttttttttttttt", "ttttttttttttttttttttttttttttt", "tttttttttttttttttttttttttttttt", "tttttttttttttttttttttttttttttz", "u", "uu", "uuu", "uuuu", "uuuuu", "uuuuuu", "uuuuuuu", "uuuuuuuu", "uuuuuuuuu", "uuuuuuuuuu", "uuuuuuuuuuu", "uuuuuuuuuuuu", "uuuuuuuuuuuuu", "uuuuuuuuuuuuuu", "uuuuuuuuuuuuuuu", "uuuuuuuuuuuuuuuu", "uuuuuuuuuuuuuuuuu", "uuuuuuuuuuuuuuuuuu", "uuuuuuuuuuuuuuuuuuu", "uuuuuuuuuuuuuuuuuuuu", "uuuuuuuuuuuuuuuuuuuuu", "uuuuuuuuuuuuuuuuuuuuuu", "uuuuuuuuuuuuuuuuuuuuuuu", "uuuuuuuuuuuuuuuuuuuuuuuu", "uuuuuuuuuuuuuuuuuuuuuuuuu", "uuuuuuuuuuuuuuuuuuuuuuuuuu", "uuuuuuuuuuuuuuuuuuuuuuuuuuu", "uuuuuuuuuuuuuuuuuuuuuuuuuuuu", "uuuuuuuuuuuuuuuuuuuuuuuuuuuuu", "uuuuuuuuuuuuuuuuuuuuuuuuuuuuuu", "uuuuuuuuuuuuuuuuuuuuuuuuuuuuuz", "v", "vv", "vvv", "vvvv", "vvvvv", "vvvvvv", "vvvvvvv", "vvvvvvvv", "vvvvvvvvv", "vvvvvvvvvv", "vvvvvvvvvvv", "vvvvvvvvvvvv", "vvvvvvvvvvvvv", "vvvvvvvvvvvvvv", "vvvvvvvvvvvvvvv", "vvvvvvvvvvvvvvvv", "vvvvvvvvvvvvvvvvv", "vvvvvvvvvvvvvvvvvv", "vvvvvvvvvvvvvvvvvvv", "vvvvvvvvvvvvvvvvvvvv", "vvvvvvvvvvvvvvvvvvvvv", "vvvvvvvvvvvvvvvvvvvvvv", "vvvvvvvvvvvvvvvvvvvvvvv", "vvvvvvvvvvvvvvvvvvvvvvvv", "vvvvvvvvvvvvvvvvvvvvvvvvv", "vvvvvvvvvvvvvvvvvvvvvvvvvv", "vvvvvvvvvvvvvvvvvvvvvvvvvvv", "vvvvvvvvvvvvvvvvvvvvvvvvvvvv", "vvvvvvvvvvvvvvvvvvvvvvvvvvvvv", "vvvvvvvvvvvvvvvvvvvvvvvvvvvvvv", "vvvvvvvvvvvvvvvvvvvvvvvvvvvvvz", "w", "ww", "www", "wwww", "wwwww", "wwwwww", "wwwwwww", "wwwwwwww", "wwwwwwwww", "wwwwwwwwww", "wwwwwwwwwww", "wwwwwwwwwwww", "wwwwwwwwwwwww", "wwwwwwwwwwwwww", "wwwwwwwwwwwwwww", "wwwwwwwwwwwwwwww", "wwwwwwwwwwwwwwwww", "wwwwwwwwwwwwwwwwww", "wwwwwwwwwwwwwwwwwww", "wwwwwwwwwwwwwwwwwwww", "wwwwwwwwwwwwwwwwwwwww", "wwwwwwwwwwwwwwwwwwwwww", "wwwwwwwwwwwwwwwwwwwwwww", "wwwwwwwwwwwwwwwwwwwwwwww", "wwwwwwwwwwwwwwwwwwwwwwwww", "wwwwwwwwwwwwwwwwwwwwwwwwww", "wwwwwwwwwwwwwwwwwwwwwwwwwww", "wwwwwwwwwwwwwwwwwwwwwwwwwwww", "wwwwwwwwwwwwwwwwwwwwwwwwwwwww", "wwwwwwwwwwwwwwwwwwwwwwwwwwwwww", "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwz", "x", "xx", "xxx", "xxxx", "xxxxx", "xxxxxx", "xxxxxxx", "xxxxxxxx", "xxxxxxxxx", "xxxxxxxxxx", "xxxxxxxxxxx", "xxxxxxxxxxxx", "xxxxxxxxxxxxx", "xxxxxxxxxxxxxx", "xxxxxxxxxxxxxxx", "xxxxxxxxxxxxxxxx", "xxxxxxxxxxxxxxxxx", "xxxxxxxxxxxxxxxxxx", "xxxxxxxxxxxxxxxxxxx", "xxxxxxxxxxxxxxxxxxxx", "xxxxxxxxxxxxxxxxxxxxx", "xxxxxxxxxxxxxxxxxxxxxx", "xxxxxxxxxxxxxxxxxxxxxxx", "xxxxxxxxxxxxxxxxxxxxxxxx", "xxxxxxxxxxxxxxxxxxxxxxxxx", "xxxxxxxxxxxxxxxxxxxxxxxxxx", "xxxxxxxxxxxxxxxxxxxxxxxxxxx", "xxxxxxxxxxxxxxxxxxxxxxxxxxxx", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxx", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx", "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxz", "y", "yy", "yyy", "yyyy", "yyyyy", "yyyyyy", "yyyyyyy", "yyyyyyyy", "yyyyyyyyy", "yyyyyyyyyy", "yyyyyyyyyyy", "yyyyyyyyyyyy", "yyyyyyyyyyyyy", "yyyyyyyyyyyyyy", "yyyyyyyyyyyyyyy", "yyyyyyyyyyyyyyyy", "yyyyyyyyyyyyyyyyy", "yyyyyyyyyyyyyyyyyy", "yyyyyyyyyyyyyyyyyyy", "yyyyyyyyyyyyyyyyyyyy", "yyyyyyyyyyyyyyyyyyyyy", "yyyyyyyyyyyyyyyyyyyyyy", "yyyyyyyyyyyyyyyyyyyyyyy", "yyyyyyyyyyyyyyyyyyyyyyyy", "yyyyyyyyyyyyyyyyyyyyyyyyy", "yyyyyyyyyyyyyyyyyyyyyyyyyy", "yyyyyyyyyyyyyyyyyyyyyyyyyyy", "yyyyyyyyyyyyyyyyyyyyyyyyyyyy", "yyyyyyyyyyyyyyyyyyyyyyyyyyyyy", "yyyyyyyyyyyyyyyyyyyyyyyyyyyyyy", "yyyyyyyyyyyyyyyyyyyyyyyyyyyyyz" })));
            Console.WriteLine(JsonConvert.SerializeObject(FindAllConcatenatedWordsInADict(new[] { "rfkqyuqfjkx", "vnrtysfrzrmzl", "gfve", "qfpd", "lqdqrrcrwdnxeuo", "q", "klaitgdphcspij", "hbsfyfv", "adzpbfudkklrw", "aozmixr", "ife", "feclhbvfuk", "yeqfqojwtw", "sileeztxwjl", "ngbqqmbxqcqp", "khhqr", "dwfcayssyoqc", "omwufbdfxu", "zhift", "kczvhsybloet", "crfhpxprbsshsjxd", "ilebxwbcto", "yaxzfbjbkrxi", "imqpzwmshlpj", "ta", "hbuxhwadlpto", "eziwkmg", "ovqzgdixrpddzp", "c", "wnqwqecyjyib", "jy", "mjfqwltvzk", "tpvo", "phckcyufdqml", "lim", "lfz", "tgygdt", "nhcvpf", "fbrpzlk", "shwywshtdgmb", "bkkxcvg", "monmwvytby", "nuqhmfj", "qtg", "cwkuzyamnerp", "fmwevhwlezo", "ye", "hbrcewjxvcezi", "tiq", "tfsrptug", "iznorvonzjfea", "gama", "apwlmbzit", "s", "hzkosvn", "nberblt", "kggdgpljfisylt", "mf", "h", "bljvkypcflsaqe", "cijcyrgmqirz", "iaxakholawoydvch", "e", "gttxwpuk", "jf", "xbrtspfttota", "sngqvoijxuv", "bztvaal", "zxbshnrvbykjql", "zz", "mlvyoshiktodnsjj", "qplci", "lzqrxl", "qxru", "ygjtyzleizme", "inx", "lwhhjwsl", "endjvxjyghrveu", "phknqtsdtwxcktmw", "wsdthzmlmbhjkm", "u", "pbqurqfxgqlojmws", "mowsjvpvhznbsi", "hdkbdxqg", "ge", "pzchrgef", "ukmcowoe", "nwhpiid", "xdnnl", "n", "yjyssbsoc", "cdzcuunkrf", "uvouaghhcyvmlk", "aajpfpyljt", "jpyntsefxi", "wjute", "y", "pbcnmhf", "qmmidmvkn", "xmywegmtuno", "vuzygv", "uxtrdsdfzfssmel", "odjgdgzfmrazvnd", "a", "rdkugsbdpawxi", "ivd", "bbqeonycaegxfj", "lrfkraoheucsvpi", "eqrswgkaaaohxx", "hqjtkqaqh", "berbpmglbjipnuj", "wogwczlkyrde", "aqufowbig", "snjniegvdvotu", "ocedkt", "bbufnxorixibbd", "rzuqsyr", "qghoy", "evcuanuujszitaoa", "wsx", "glafbwzdd", "znrvjqeyqi", "npitruijvyllsi", "objltu", "ryp", "nvybsfrxtlfmp", "id", "zoolzslgd", "owijatklvjzscizr", "upmsoxftumyxifyu", "xucubv", "fctkqlroq", "zjv", "wzi", "ppvs", "mflvioemycnphfjt", "nwedtubynsb", "repgcx", "gsfomhvpmy", "kdohe", "tyycsibbeaxn", "wjkfvabn", "llkmagl", "thkglauzgkeuly", "paeurdvexqlw", "akdt", "ihmfrj", "janxk", "rqdll", "cyhbsuxnlftmjc", "yybwsjmajbwtuhkk", "ovytgaufpjl", "iwbnzhybsx", "mumbh", "jqmdabmyu", "br", "lwstjkoxbczkj", "vhsgzvwiixxaob", "fso", "qnebmfl", "ooetjiz", "lq", "msxphqdgz", "mqhoggvrvjqrp", "xbhkkfg", "zxjegsyovdrmw", "jav", "mshoj", "ax", "biztkfomz", "hujdmcyxdqteqja", "gqgsomonv", "reqqzzpw", "lihdnvud", "lznfhbaokxvce", "fhxbldylqqewdnj", "rlbskqgfvn", "lfvobeyolyy", "v", "iwh", "fpbuiujlolnjl", "gvwxljbo", "ypaotdzjxxrsc", "mwrvel", "umzpnoiei", "ogwilaswn", "yw", "egdgye", "hsrznlzrf", "mwdgxaigmxpy", "yaqgault", "dtlg", "cyvfiykmkllf", "zxqyhvizqmamj", "lvvgoifltzywueyp", "abinmy", "ppzaecvmx", "qsmzc", "iddymnl", "uskihek", "evxtehxtbthq", "jvtfzddlgch", "czohpyewf", "ufzazyxtqxcu", "brxpfymuvfvs", "xrrcfuusicc", "aqhlswbzievij", "rv", "udvmara", "upityz", "fecd", "suxteeitxtg", "dfuydrtbfypbn", "cypqodxr", "wikfuxwjht", "jrliuaifpp", "vkmxys", "wvpfyfpkvgthq", "rmajxis", "jncxgviyu", "av", "nmhskodmidaj", "lkfrimprrhen", "uip", "hstyopbvuiqc", "p", "vwduwmjpblqo", "fnxwgqtvwztje", "xwnbcuggl", "iehimvoymyjasin", "spsqiu", "flhyfac", "mqrbq", "pstsxhplrrmbeddv", "hnegtuxx", "alsyxezjwtlwmxv", "jtxytykkcku", "bhhlovgcx", "xhhivxnutkx", "had", "aysulvk", "m", "anhsyxli", "jdkgfc", "potn", "lcibpxkidmwexp", "gwoxjicdkv", "tltienw", "ngiutnuqbzi", "o", "tzlyb", "vumnwehj", "os", "np", "lhv", "uzvgyeette", "ipfvr", "lpprjjalchhhcmh", "k", "pciulccqssaqgd", "tp", "dmzdzveslyjad", "wtsbhgkd", "eouxbldsxzm", "vhtonlampljgzyve", "xhnlcrldtfthul", "xhflc", "upgei", "rlaks", "yfqvnvtnqspyjbxr", "phouoyhvls", "voibuvbhhjcdflvl", "rgorfbjrofokggaf", "dqhqats", "zchpicyuawpovm", "yzwfor", "koat", "pybf", "fhdzsbiyjld", "gznfnqydisn", "xz", "po", "tcjup", "wygsnxk", "kqlima", "fgxnuohrnhg", "publurhztntgmimc", "zuufzphd", "iucrmmmjqtcey", "wnnbq", "rghzyz", "ukjqsjbmp", "mdtrgv", "vyeikgjdnml", "kxwldnmi", "apzuhsbssaxj", "tkbkoljyodlipof", "nkq", "ktwtj", "vgmkgjwle", "t", "agylw", "vomtuy", "jbtvitkqn", "vtdxwrclpspcn", "rdrls", "yxfeoh", "upj", "myctacn", "fdnor", "ahqghzhoqprgkym", "phiuvdv", "jp", "fdgpouzjwbq", "hqoyefmugjvewhxu", "qfzwuwe", "fnsbijkeepyxry", "oja", "qthkcij", "zpmqfbmnr", "ybaibmzonzqlnmd", "svo", "gjftyfehik", "jfrfgznuaytvaegm", "aljhrx", "odjq", "ogwaxrssjxgvnka", "zaqswwofedxj", "lugpktauixp", "dc", "odknlbvxrs", "jeobu", "vqythyvzxbcgrlbg", "hwc", "erpbaxq", "ujxcxck", "rrklkb", "wlrwyuy", "zmg", "yyhga", "xwdbycdu", "htedgvsrhchox", "wr", "suhesetv", "jonqwhkwezjvjgg", "sqqyrxtjkcalswq", "hvyimhe", "pjzdkmoue", "zbphmgoxq", "lbdlcumdgixjbcq", "ztzdjqmadthtdmv", "qcagsyqggcf", "if", "jpjxcjyi", "chyicqibxdgkqtg", "iwpdklhum", "wljmg", "micmun", "npdbamofynykqv", "ijsnfkpfy", "lmq", "oyjmeqvhcrvgm", "mqopusqktdthpvz", "fz", "r", "qbsqtipq", "nxtsnason", "xbpipyhh", "topsuqomfjrd", "islif", "gbndakaq", "bwnkxnwpzeoohlx", "hrtbfnq", "fguvomeepxoffg", "mat", "dzfpfnwbfuj", "onlvy", "cwcchvsasdylb", "rxfcztzqopdi", "ybrhodjn", "oqkijy", "ncvrjo", "dphbfaal", "xgtpdtkz", "sebevsopjvciwljf", "rcumyacqdapwczen", "mabkapuoud", "pbozezeygljfftvy", "bvazmzbndl", "vl", "qiaixdtbhqvlzd", "ffjfb", "svthrfmkoxbho", "cvet", "ucgqyvopafyttrh", "lbgihet", "naiqyufxffdw", "vruh", "uz", "ukffmudygjavem", "dccamymhp", "wofwgjkykm", "fbuujzxhln", "kmm", "lzandlltowjpwsal", "fapfvrmezbsjxs", "wiw", "sc", "soqlh", "hzaplclkwl", "gcdqbcdwbwa", "gadgt", "pgowefka", "juffuguqepwnfh", "nbuinl", "cpdxf", "sox", "fq", "lfnrhgsxkhx", "xrcorfygjxpi", "mwtqjwbhgh", "loc", "fkglorkkvx", "nlzdhucvayrz", "azefobxutitrf", "rlrstkcbtikklmh", "ggk", "sbphcejuylh", "nraoenhd", "zngyodiqlchxyycx", "rrbhfwohfv", "krzolrglgn", "cpjesdzy", "yoifoyg", "hqqevqjugi", "ahmv", "xgaujnyclcjq", "evhyfnlohavrj", "byyvhgh", "hyw", "kedhvwy", "ysljsqminajfipds", "rglnpxfqwu", "cibpynkxg", "su", "mbntqrlwyampdg", "nig", "ldhlhqdyjcfhu", "jfymrbafmyoc", "tyjmnhlfnrtz", "dlazixtlxyvm", "fbiguhsfuqo", "rhymsno", "rkbdlchs", "ocbbwwd", "astaiamnepwkya", "mplirup", "edkxjq", "g", "exlwulswtvot", "tlnc", "vnrrzerz", "ygeraoozbtt", "yyifkin", "eo", "ua", "qgztvqdolf", "rlzddjzcshvd", "khxkdxflwxme", "kk", "zylbhoaac", "cw", "iizic", "gcdxstpz", "kjwdqeg", "earjrncmmkdel", "kbesuhquepj", "nrzbllldgdmyrpgl", "hllwnqozf", "djpchowhwevbqvjj", "zsmhylnjpktb", "pxnktxkm", "fxwiaqqb", "qjwufmwresfsfaok", "aa", "d", "iobioqm", "svjgzk", "khbzp", "euexyudhrioi", "yqsj", "ngrwqpoh", "rwuvd", "eruffmlg", "bxzovyew", "faz", "pmvfvyguqdi", "jlxnoixsy", "hyfrdngjf", "ly", "eibcapetpmeaid", "tpnwwiif", "pfgsp", "kvhhwkzvtvlhhb", "pjxurgqbtldims", "rncplkeweoirje", "akyprzzphew", "wyvfpjyglzrmhfqp", "ubheeqt", "rmbxlcmn", "taqakgim", "apsbu", "khwnykughmwrlk", "vtdlzwpbhcsbvjno", "tffmjggrmyil", "schgwrrzt", "mvndmua", "nlwpw", "glvbtkegzjs", "piwllpgnlpcnezqs", "xkelind", "urtxsezrwz", "zechoc", "vfaimxrqnyiq", "ybugjsblhzfravzn", "btgcpqwovwp", "zgxgodlhmix", "sfzdknoxzassc", "wgzvqkxuqrsqxs", "dwneyqisozq", "fg", "vhfsf", "uspujvqhydw", "eadosqafyxbmzgr", "tyff", "blolplosqnfcwx", "uwkl", "puenodlvotb", "iizudxqjvfnky", "cjcywjkfvukvveq", "jrxd", "igwb", "dftdyelydzyummmt", "uvfmaicednym", "oai", "higfkfavgeemcgo", "naefganqo", "iqebfibigljbc", "ulicojzjfrc", "igxprunj", "cymbrl", "fqmwciqtynca", "zjyagi", "mzuejrttefhdwqc", "zyiurxvf", "wrjxffzbjexsh", "wrxw", "mhrbdxjwi", "htknfa", "wfrvxqdkhbwwef", "vqsghhhutdget", "cwupzrts", "hbjnb", "wpccoa", "nx", "howbzhaoscgyk", "bilt", "wqqatye", "zceuuwg", "jxzon", "kkfj", "bwsezd", "ifdegsyjtswselk", "xweimxlnzoh", "tqthlftjblnpht", "ww", "ss", "b", "jmruuqscwjp", "nxbk", "wd", "cqkrtbxgzg", "xhppcjnq", "cfq", "tkkolzcfi", "wblxki", "ijeglxsvc", "kcqjjwcwuhvzydm", "gubqavlqffhrzz", "hiwxrgftittd", "caybc", "ncsyjlzlxyyklc", "poxcgnexmaajzuha", "dhaccuualacyl", "mtkewbprs", "oncggqvr", "sqqoffmwkplsgbrp", "ioajuppvqluhbdet", "dzwwzaelmo", "afumtqugec", "wglucmugwqi", "zveswrjevfz", "nxlbkak", "pzcejvxzeoybb", "fd", "vewj", "ivws", "zjhudtpqsfc", "zcmukotirrxx", "zksmx", "umofzhhowyftz", "zbotrokaxaryxlk", "ueolqk", "dxmzhoq", "zvu", "cjl", "esfmqgvxwfy", "npbep", "vbgjtbv", "poeugoqynkbfiv", "fewjjscjrei", "yqssxzsydgllfzmo", "urxkwcypctjkabi", "wqtldwhjouas", "tovdtkr", "onzgeyddkqwuhnim", "ffxviyvsktqrfa", "qujhd", "pvcz", "hiyjlkxmeplnrvxg", "hdykehkefp", "vepcxhozpjxtreyn", "liguhuxudbnh", "f", "ordxzm", "klgohcmmbukz", "yrmooliaobbnlap", "dutnbetocxylcey", "ywdsjegd", "cr", "blbxhjsgcuoxmqft", "ngzdc", "srfyjjumcbxole", "dazwzwtdjoyuqeqj", "xazjarqgfm", "fxyfqbeoktcc", "qrsjchxp", "iltaqzawhgu", "sgenjcfxr", "yfikp", "dvwhbyumthkiktb", "walsx", "jyajrkcvysicisab", "brdeumb", "tviihjwxdcz", "dnrrgmem", "ydgxlrjzucxyid", "cdvdpvjlagwmg", "ngnpxjkxims", "gvyhnchlimsxc", "w", "jtizpezjl", "qe", "rjzv", "vhnqvi", "qm", "iedzqswrsnfmnn", "lt", "utqfcqyrrwm", "wtelvsqrru", "fjwrhjcrtbcytn", "qmqxceuohpiffaq", "rmoybqjjgdyo", "pmxttqftypfexlv", "tg", "qa", "iqbqjlnpbf", "kgaynkddbzllecd", "tccvslp", "curkxfoimnw", "fvnyqkzlheruxr", "iiygnzfov", "coqs", "oa", "eiu", "vzemmxtklis", "lxu", "nrwsjaxzwmh", "tdayz", "oxbbemejgosgcynf", "ykbcn", "hesvnctfvdsp", "ku", "rjhykpadahbhj", "at", "sxlngbtxmqr", "wqrom", "qzyabzrco", "rbbyklndcqdj", "cnsmgmwmpbgjq", "krvnaf", "qrwfajnfahyqocdb", "fnlaozmff", "vmoymbmytjvfcgt", "cijyy", "jdgwjbztl", "swmalgbgpaplqgz", "hfl", "typttkrpfvx", "tkzpzrscwbx", "bwfqqvjcukjbsg", "nxqmxr", "x", "eyavnz", "il", "dhthp", "eyelg", "npsoqsw", "reogbmveofvusdsx", "jvdrjkhxkq", "qzjbrpljwuzpl", "czqeevvbvcwh", "vzuszqvhlmapty", "yu", "yldwwgezlqur", "vorxwgdtgjilgydq", "pknt", "bgihl", "ckorgrm", "ixylxjmlfv", "bpoaboylced", "zea", "igfagitkrext", "ipvqq", "dmoerc", "oqxbypihdv", "dtjrrkxro", "rexuhucxpi", "bvmuyarjwqpcoywa", "qwdmfpwvamisns", "bhopoqdsref", "tmnm", "cre", "ktrniqwoofoeenbz", "vlrfcsftapyujmw", "updqikocrdyex", "bcxw", "eaum", "oklsqebuzeziisw", "fzgyhvnwjcns", "dybjywyaodsyw", "lmu", "eocfru", "ztlbggsuzctoc", "ilfzpszgrgj", "imqypqo", "fump", "sjvmsbrcfwretbie", "oxpmplpcg", "wmqigymr", "qevdyd", "gmuyytguexnyc", "hwialkbjgzc", "lmg", "gijjy", "lplrsxznfkoklxlv", "xrbasbznvxas", "twn", "bhqultkyfq", "saeq", "xbuw", "zd", "kng", "uoay", "kfykd", "armuwp", "gtghfxf", "gpucqwbihemixqmy", "jedyedimaa", "pbdrx", "toxmxzimgfao", "zlteob", "adoshnx", "ufgmypupei", "rqyex", "ljhqsaneicvaerqx", "ng", "sid", "zagpiuiia", "re", "oadojxmvgqgdodw", "jszyeruwnupqgmy", "jxigaskpj", "zpsbhgokwtfcisj", "vep", "ebwrcpafxzhb", "gjykhz", "mfomgxjphcscuxj", "iwbdvusywqlsc", "opvrnx", "mkgiwfvqfkotpdz", "inpobubzbvstk", "vubuucilxyh", "bci", "dibmye", "rlcnvnuuqfvhw", "oorbyyiigppuft", "swpksfdxicemjbf", "goabwrqdoudf", "yjutkeqakoarru", "wuznnlyd", "vfelxvtggkkk", "mxlwbkbklbwfsvr", "advraqovan", "smkln", "jxxvzdjlpyurxpj", "ssebtpznwoytjefo", "dynaiukctgrzjx", "irzosjuncvh", "hcnhhrajahitn", "vwtifcoqepqyzwya", "kddxywvgqxo", "syxngevs", "batvzmziq", "mjewiyo", "pzsupxoflq", "byzhtvvpj", "cqnlvlzr", "akvmxzbaei", "mwo", "vg", "ekfkuajjogbxhjii", "isdbplotyak", "jvkmxhtmyznha", "lqjnqzrwrmgt", "mbbhfli", "bpeohsufree", "ajrcsfogh", "lucidbnlysamvy", "tutjdfnvhahxy", "urbrmmadea", "hghv", "acnjx", "athltizloasimp", "gu", "rjfozvgmdakdhao", "iephs", "uztnpqhdl", "rfuyp", "crcszmgplszwfn", "zihegt", "xbspa", "cjbmsamjyqqrasz", "ghzlgnfoas", "ljxl", "cnumquohlcgt", "jm", "mfccj", "hfedli", "vtpieworwhyiucs", "tdtuquartspkotm", "pnkeluekvelj", "ugrloq", "zljmwt", "fkyvqguqq", "tpjidglpxqfxv", "l", "tvvimvroz", "yy", "opwyfovdz", "pwlumocnyuoume", "vjqpzkcfc", "ihicd", "dtttiixlhpikbv", "goblttgvmndkqgg", "gwsibcqahmyyeagk", "prtvoju", "lcblwidhjpu", "kbu", "pey", "gkzrpc", "bqajopjjlfthe", "bc", "lqs", "zkndgojnjnxqsoqi", "zyesldujjlp", "drswybwlfyzph", "xzluwbtmoxokk", "bedrqfui", "opajzeahv", "lehdfnr", "mnlpimduzgmwszc", "velbhj", "miwdn", "wruqc", "kscfodjxg", "wcbm" })));
            
        }

        private static IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            var trie = new Trie();
            foreach (var word in words)
                trie.Set(word);

            var res = new List<string>();

            foreach (var word in words)
            {
                var dp = new short[word.Length + 1];
                dp[0] = 1;

                for (short i = 0; i < word.Length; i++)
                {
                    if (dp[i] == 0) continue;
                    var tree = trie;
                    for (short j = i; j < word.Length; j++)
                    {
                        if (tree.childs.ContainsKey(word[j]))
                        {
                            tree = tree.childs[word[j]];
                            if (tree.end)
                                dp[j + 1]++;
                        }
                        else break;
                    }

                    if (dp[word.Length] >= 2)
                    {
                        res.Add(word);
                        break;
                    }
                }
            }
            return res;
        }

        private class Trie
        {
            public bool end = false;
            public Dictionary<char, Trie> childs;

            public Trie()
            {
                childs = new Dictionary<char, Trie>();
            }

            public void Set(string input)
            {
                var temp = this;
                foreach (char c in input)
                {
                    if (!temp.childs.ContainsKey(c))
                        temp.childs.Add(c, new Trie());
                    temp = temp.childs[c];
                }
                temp.end = true;
            }
        }
    }
}