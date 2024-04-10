# Word Finder

This application was developed taking in consideration different search algorithms. 
Based on my research I decided to do some performance test with two options that seemed interesting to me (BluerMoore algorithm and using a Trie or Prefix Tree data structure). In the end, I chose to use the Trie data structure, which I implemented from a NugetPackage, as it was not an impediment  in the exercise instructions (URL: https://www.nuget.org/packages/TrieNet2). 

Based on the spike I performed, I decided to use a Trie data structure because it has better memory and resource management than BlueMoore or other options that I found. Additionally, it adapts to the application's requirements, providing good response performance and resource optimization. Additionally, I tried to apply some good practices in the program such as Dependency Injection, Constants, Extension Methods, Interfaces, SOLID principles, etc.

## Usage Instructions

To use the application, you should select a menu option: 

1. You shoulld first build the matrix and choose the words you want to search for.
2. Take in consideration that you can only insert letters and vowels separated by commas; otherwise, the application will return an error.
3. Once you have entered the matrix and the characters you want to search for, so you will need to select option 3 to start the search.

Example:
![Screenshot 2024-04-09 221221](https://github.com/frankasg/Qu_repo/assets/40705634/c975977d-cef9-4c0d-9dfd-1a9ca8f8a4b9)
