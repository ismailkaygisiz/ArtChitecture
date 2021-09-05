import 'package:dio/dio.dart';
import 'package:flutter_ui/core/interceptors/http_interceptor.dart';
import 'package:flutter_ui/environments/api.dart';

/// ArtChitecture Custom HttpClient
/// Using HttpClient [Dio]
/// Using Interceptor [HttpInterceptor]
class HttpClient {
  late Dio _httpClient;

  Dio get httpClient => _httpClient;

  HttpClient() : _httpClient = Dio() {
    _httpClient.options = BaseOptions(
      baseUrl: Environments.API_URL,
      connectTimeout: 8000,
      receiveTimeout: 8000,
      validateStatus: (status) => true,
    );

    _httpClient.interceptors.add(HttpInterceptor());
  }

  void addInterceptor(Interceptor interceptor) {
    _httpClient.interceptors.add(interceptor);
  }

  void addInterceptors(Iterable<Interceptor> interceptors) {
    _httpClient.interceptors.addAll(interceptors);
  }

  Future<Response<T?>?> get<T>(
    String path, {
    Map<String, dynamic>? queryParameters,
    Options? options,
  }) async {
    options?.validateStatus = (status) => true;

    return await _httpClient.get<T>(
      path,
      queryParameters: queryParameters,
      options: options,
    );
  }

  Future<Response<T?>?> post<T>(
    String path, {
    dynamic body,
    Map<String, dynamic>? queryParameters,
    Options? options,
  }) async {
    options?.validateStatus = (status) => true;

    return await _httpClient.post<T>(
      path,
      data: body,
      queryParameters: queryParameters,
      options: options,
    );
  }

  Future<Response<T?>?> put<T>(
    String path, {
    dynamic body,
    Map<String, dynamic>? queryParameters,
    Options? options,
  }) async {
    options?.validateStatus = (status) => true;

    return await _httpClient.put<T>(
      path,
      data: body,
      queryParameters: queryParameters,
      options: options,
    );
  }

  Future<Response<T?>?> delete<T>(
    String path, {
    dynamic body,
    Map<String, dynamic>? queryParameters,
    Options? options,
  }) async {
    options?.validateStatus = (status) => true;

    return await _httpClient.delete<T>(
      path,
      data: body,
      queryParameters: queryParameters,
      options: options,
    );
  }

  Future<Response<T?>?> head<T>(
    String path, {
    dynamic body,
    Map<String, dynamic>? queryParameters,
    Options? options,
  }) async {
    options?.validateStatus = (status) => true;

    return await _httpClient.head<T>(
      path,
      data: body,
      queryParameters: queryParameters,
      options: options,
    );
  }

  Future<Response<T?>?> patch<T>(
    String path, {
    dynamic body,
    Map<String, dynamic>? queryParameters,
    Options? options,
  }) async {
    options?.validateStatus = (status) => true;

    return await _httpClient.patch<T>(
      path,
      data: body,
      queryParameters: queryParameters,
      options: options,
    );
  }

  Future<Response<T?>?> request<T>(
    String path, {
    dynamic body,
    Map<String, dynamic>? queryParameters,
    Options? options,
  }) async {
    options?.validateStatus = (status) => true;

    return await _httpClient.request<T>(
      path,
      data: body,
      queryParameters: queryParameters,
      options: options,
    );
  }
}
