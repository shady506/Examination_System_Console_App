# Examination_System
# Examination System

A **C# Console Application** that simulates a simple Examination System with separate **Teacher Mode** and **Student Mode**.

The project was built as a training project to practice **Object-Oriented Programming (OOP)** concepts, inheritance, polymorphism, collections, and basic system design in C#.

## Features

### Teacher Mode

The teacher can create an exam by:

* Choosing the number of questions.
* Selecting the question type:

  * True / False
  * Choose One
  * Multiple Choice
* Selecting the question difficulty:

  * Easy
  * Medium
  * Hard
* Adding the question text.
* Setting the question mark.
* Adding answer choices.
* Setting the correct answer(s).

### Student Mode

The student can:

* Choose the exam difficulty level.
* Confirm before starting the exam.
* View the exam date and time.
* Answer the questions.
* Get the correct answer for each question after finishing.
* View the final score and total marks.

## Question Types

The system currently supports three types of questions:

### True / False

The student chooses between:

* True
* False

### Choose One

The student chooses one answer from multiple available choices.

### Multiple Choice

The student can select multiple correct answers.

## Question Levels

Each question can have one of three difficulty levels:

* Easy
* Medium
* Hard

Students can choose which level of exam they want to take.

## Project Structure

The main classes in the project include:

* `SystemManager` — Handles the main system flow, Teacher Mode, and Student Mode.
* `Exam` — Stores the exam information and questions.
* `Question` — Base class for all question types.
* `TrueOrFalseQuestion` — Represents True / False questions.
* `ChooseOneQuestion` — Represents questions with one correct answer.
* `MultipleChoiceQuestion` — Represents questions with multiple correct answers.

## OOP Concepts Practiced

This project was mainly created to practice C# and Object-Oriented Programming concepts, including:

* Classes & Objects
* Encapsulation
* Inheritance
* Polymorphism
* Abstraction
* Enums
* Method Overriding
* Collections (`List<T>`)
* Pattern Matching with `is`
* Properties
* Conditional Statements
* Loops
* Exception Handling
* Basic Console Application Design

## Technologies

* **C#**
* **.NET**
* **Console Application**
* **Object-Oriented Programming**

## How It Works

The application starts with a main menu:

```text
=================================
       Examination System
=================================

1. Teacher Mode
2. Student Mode
```

### Teacher Flow

```text
Teacher Mode
     ↓
Number of Questions
     ↓
Question Type
     ↓
Question Level
     ↓
Question Text
     ↓
Question Mark
     ↓
Answer Choices
     ↓
Correct Answer
```

### Student Flow

```text
Student Mode
     ↓
Choose Exam Level
     ↓
Confirm Starting Exam
     ↓
Display Date & Time
     ↓
Answer Questions
     ↓
Show Correct Answers
     ↓
Calculate Final Result
```

## Example

The student can select an exam level:

```text
Choose Exam Level:

1. Easy
2. Medium
3. Hard
```

After confirmation, the exam starts and displays:

```text
==============================================
              EXAMINATION
==============================================

Exam Level : Easy
Date       : 05/10/2026
Time       : 11:30:20 PM
```

After completing the exam, the student receives the correct answers and final result.

## Purpose

This project is a **training Console Application** built to strengthen my understanding of **C# OOP concepts and object-oriented system design** through a practical example.

More features and improvements may be added in future versions.

## Author

**Shady Ashraf**

.NET Backend Developer

GitHub: [shady506](https://github.com/shady506)
