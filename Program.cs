﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine();

//1. IsUnique problem
//var isUnique = DSA.IsUnique("test");
//Console.WriteLine($"isUnique: {isUnique}");

//var isUnique = DSA.IsUniqueFast("test");       
//Console.WriteLine($"isUnique fast: {isUnique}");

//var isPermutation = DSA.CheckPermutationBySorting("abc","cba");
//Console.WriteLine($"isPermutation: {isPermutation}");

//        var isPermutation = DSA.CheckPermutationByCount("abc","cbaaa");
//        Console.WriteLine($"isPermutation: {isPermutation}");

//        var url = DSA.URLify("Mr John Smith is not good          ".ToCharArray(),25);
//        Console.WriteLine($"url: {url}");

// var isPermutationOfPalindrome = DSA.isPermutationOfPalindrome("tact cao");
// Console.WriteLine($" isPermutationOfPalindrome: {isPermutationOfPalindrome}");

// var isPermutationOfPalindrome2 = DSA.IsPermutationOfPalindromeOptimized("tact coa");
// Console.WriteLine($"isPermutationOfPalindrome2: {isPermutationOfPalindrome2}");

var isPermutationOfPalindrome3 = DSA.IsPermutationOfPalindromeByBitVector("tact cao");
Console.WriteLine($"isPermutationOfPalindrome3: {isPermutationOfPalindrome3}");

Console.WriteLine();
       