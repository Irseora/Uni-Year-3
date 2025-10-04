# Programare concurenta - Threads

# import threading
# import time

# def print_numbers():
#     for i in range(5):
#         print(f"Number: {i}")
#         time.sleep(1)

# def print_letters():
#     for letter in 'ABCDE':
#         print(f"Letter: {letter}")
#         time.sleep(1)

# thread1 = threading.Thread(target=print_numbers)
# thread2 = threading.Thread(target=print_letters)

# thread1.start()
# thread2.start()

# thread1.join()
# thread2.join()

# print("Thread execution completed.")

# --------------------------------------------------------

# Multiprocessing

# import multiprocessing
# import time

# def print_numbers():
#     for i in range(5):
#         print(f"Number: {i}", flush=True)
#         time.sleep(1)

# def print_letters():
#     for letter in 'ABCDE':
#         print(f"Letter: {letter}", flush=True)
#         time.sleep(1)

# if __name__ == "__main__":
#     process1 = multiprocessing.Process(target=print_numbers)
#     process2 = multiprocessing.Process(target=print_letters)

#     process1.start()
#     process2.start()

#     process1.join()
#     process2.join()

#     print("Multiprocessing execution completed.")

# --------------------------------------------------------

# Async

# import asyncio

# async def print_numbers():
#     for i in range(5):
#         print(f"Number: {i}")
#         await asyncio.sleep(1)

# async def print_letters():
#     for letter in 'ABCDE':
#         print(f"Letter: {letter}")
#         await asyncio.sleep(1)

# async def main():
#     await asyncio.gather(print_numbers(), print_letters())

# asyncio.run(main())
# print("Async execution completed.")

# --------------------------------------------------------6

import asyncio

async def print_numbers():
    for i in range(5):
        print(f"Number: {i}")
        await asyncio.sleep(1)

async def print_letters():
    for letter in 'ABCDE':
        print(f"Letter: {letter}")
        await asyncio.sleep(1)

async def main():
    print_numbers()  # Waits for this to complete first
    await asyncio.sleep(1)
    await print_letters()  # Runs only after print_numbers() is done

asyncio.run(main())
print("Async execution completed.")