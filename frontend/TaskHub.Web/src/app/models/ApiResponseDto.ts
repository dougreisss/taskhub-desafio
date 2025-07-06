export interface ApiResponseDto<T> {
    statusCode: number;
    message: string;
    exception: string;
    data: T;
}