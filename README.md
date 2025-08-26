# Ollama Extensions for Semantic Kernel 🌐

![Ollama Extensions](https://img.shields.io/badge/Ollama%20Extensions%20for%20Semantic%20Kernel-blue?style=flat&logo=github)

Welcome to the **soenneker.semantickernel.pool.ollama** repository! This project provides Ollama-specific registration extensions for the `KernelPoolManager`, allowing you to integrate local Large Language Models (LLMs) seamlessly via Semantic Kernel. 

## Table of Contents

- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Configuration](#configuration)
- [Contributing](#contributing)
- [License](#license)
- [Support](#support)

## Features ✨

- **Ollama Integration**: Connect your local LLMs easily with Semantic Kernel.
- **Flexible Options**: Customize your kernel pool with various options for managing and limiting resources.
- **Multiple Managers**: Handle multiple instances of `KernelPoolManager` efficiently.
- **Rate Limiting**: Implement rate limiting for better control over resource usage.

## Installation ⚙️

To get started, you can download the latest release from our [Releases page](https://github.com/Lakatos179/soenneker.semantickernel.pool.ollama/releases). After downloading, follow the installation instructions provided in the release notes.

### Prerequisites

Ensure you have the following installed:

- .NET SDK
- C# Development Environment

### Steps to Install

1. Clone the repository:
   ```bash
   git clone https://github.com/Lakatos179/soenneker.semantickernel.pool.ollama.git
   ```

2. Navigate to the project directory:
   ```bash
   cd soenneker.semantickernel.pool.ollama
   ```

3. Restore the dependencies:
   ```bash
   dotnet restore
   ```

4. Build the project:
   ```bash
   dotnet build
   ```

5. For deployment, check the latest release and download the necessary files from the [Releases page](https://github.com/Lakatos179/soenneker.semantickernel.pool.ollama/releases).

## Usage 📚

To use the Ollama extensions in your project, follow these steps:

1. **Initialize the KernelPoolManager**:
   ```csharp
   var kernelPoolManager = new KernelPoolManager();
   ```

2. **Register Ollama Extensions**:
   ```csharp
   kernelPoolManager.RegisterOllamaExtensions();
   ```

3. **Configure Options**:
   ```csharp
   kernelPoolManager.Configure(new KernelOptions
   {
       RateLimit = 100,
       MaxInstances = 5
   });
   ```

4. **Start the Kernel Pool**:
   ```csharp
   kernelPoolManager.Start();
   ```

5. **Use the Kernel**:
   ```csharp
   var result = await kernelPoolManager.ExecuteAsync("Your prompt here");
   ```

## Configuration ⚙️

You can configure the `KernelPoolManager` with various options to suit your needs. Here are some common configurations:

### Rate Limiting

Set a rate limit to control how often your models can be accessed.

```csharp
var options = new KernelOptions
{
    RateLimit = 10 // Requests per second
};
```

### Instance Management

Control the number of instances to run concurrently.

```csharp
var options = new KernelOptions
{
    MaxInstances = 3 // Maximum concurrent instances
};
```

## Contributing 🤝

We welcome contributions! If you would like to contribute to this project, please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/YourFeature`).
3. Make your changes.
4. Commit your changes (`git commit -m 'Add some feature'`).
5. Push to the branch (`git push origin feature/YourFeature`).
6. Open a pull request.

## License 📄

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.

## Support 💬

For support, please check the [Releases section](https://github.com/Lakatos179/soenneker.semantickernel.pool.ollama/releases) for the latest updates and fixes. If you encounter issues, feel free to open an issue in the repository.

---

Thank you for your interest in the **soenneker.semantickernel.pool.ollama** repository. We hope this project enhances your experience with Semantic Kernel and Ollama!