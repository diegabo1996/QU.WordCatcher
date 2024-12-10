# Word Catcher Solution

## 1. Initial Analysis 🤔

The challenge required me to implement a solution to a problem that I consider a puzzle.

The problem was:

- To implement a function that receives a list of strings and compares these strings with a matrix.
- If there is a match, the function should keep track of how many times the word was found in the matrix.
- If there is no match, the function should return an empty list.

Considerations:

- The matrix is represented as a list of lists, where each list is a row of the matrix. The matrix should not exceed 64x64.
- The results should display each word and the number of times it was found in the matrix, but the word should only appear once.

Note: The solution should be efficient in terms of performance.

## 2. Analysis and Solutions 🧐

I considered this as a good opportunity to apply some very exciting concepts like:
- Clean Code
- SOLID Principles
- Domain Driven Design as Solution Architecture.
- Test Driven Development

GitHub Structure: 
- Master Branch: Production Ready Code
- [HF_Branchs]: Branch for Hot Fixes.

All these concepts will be applied over this structure:

- Domain: Class Library
	- Entities
	- Value Objects
	
- Application: Class Library
	- Services
	- Interfaces
	
- Tests: xUnit Class Library (Client)

### 2.1. Domain 🏠

In this scenario, I identified the need to create three objects and one interface. Based on the concepts of mutability and immutability, I chose to define these objects as **Entities** and a **Value Object**.  
This part of the solution has been organized within a class library called **"Domain"**.

#### Value Objects
- **Position**: This object is essential as it will be used as a pointer. It contains two attributes: `Row` and `Column`.

#### Entities
- **Matrix**: Composed of a grid (character array) and additional properties, should they be needed. It is **immutable**.
- **Word**: Composed of two properties, `Text` and `Frequency`. It is **mutable**, with its frequency updated via the `IncrementFrequency` method.

#### Interfaces
- **IWordFinder**: This interface is designed to implement the service responsible for finding words in the matrix (as required in the provided document).


### 2.2. Application 📦

In this layer, I implemented a single service (WordFinder) based on the contract IWordFinder. This service is responsible for finding words in the matrix.
The service was implemented using the Strategy Pattern, making it easy to change the algorithm in the future if needed.
The algorithm implemented is a 2D matrix searcher that processes the matrix row by row and column by column and whe it finds a match, it increments the word frequency attribute for word entity.

During the coding process, I realized there could be a better method to search for words in the matrix, based on the first letter of each word. However, by the time I identified this possibility, the initial implementation was already complete. I like to mention potential improvements for consideration.

### 2.3. Tests 🧪 (VERY IMPORTANT!)


In this layer I implemented the tests for the WordFinder service. The tests were implemented using xUnit, and they cover the following scenarios:

Default Test Methods
- Find_ShouldReturnEmpty_WhenWordStreamIsEmpty: Verifies that the method returns an empty list when the word stream is empty.
- Find_ShouldReturnWords_WhenTheyExistInMatrix: Checks that the method returns the correct words when they exist in the matrix, ensuring no duplicates in the results.
- Find_ShouldIgnoreCase_WhenMatchingWords: Ensures that the method is case-insensitive when matching words, meaning it should match words regardless of capitalization.
- Find_ShouldReturnEmpty_WhenNoWordsFound: Verifies that the method returns an empty list when no words from the stream are found in the matrix.

Final Test Mehod (The Boss)
- Find_ShouldReturnTop10Words_InDescendingOrder: Ensures that the method returns the top 10 words, sorted in descending order of frequency, when more than 10 words exist. This is the most complete test case and covers the most complex scenario.

##### These tests were thinked to be modified by you to test any scenario if you want or only for debugging purposes.

## 3. TimeShift 🕰️

| **Task**                                | **Estimated Hours** | **Actual Hours** |
|-----------------------------------------|---------------------|------------------|
| Initial analysis and requirements setup | 1                   | 1                |
| Domain layer Analisis and Design        | 2                   | 3                |
| Application layer design (`WordFinder`) | 2                   | 1                |
| Unit test implementation                | 4                   | 4                |
| Documentation and final review          | 3                   | 4                |
|		(Chat GPT Investigation 😉)	      | 2                   | 2                |
| **Total**                               | **14**              | **15**           |

## 4. Conclusion 🎉

This puzzle was a great opportunity to apply some of the concepts I have been studying and practicing. I believe the solution is efficient and meets the requirements of the challenge. I am confident that the code is clean, well-structured, and easy to maintain. I am happy with the result and look forward to receiving feedback on my solution.

## 5. Next Steps? 🚀

- Add support for diagonal word search.
- Implement a more efficient search algorithm based on the first letter of each word.
- Implement a more complex test case to cover additional scenarios.
- Refactor the code to improve performance and readability.
- Add logging and error handling to the application.
- Implement a user interface to interact with the application (Console or .NET MAUI)

Hope you enjoy read it as I enjoyed to programming it 😊

Vist my Web Site: [www.diegoleon.me](https://www.diegoleon.me)
```

NOTE: This README.md file was not written by any LLM, but parts of the text were improved with GPT-3 to correct grammar mistakes and enhance readability.