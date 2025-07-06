export interface ApiResponseDto<T> {
    StatusCode: number;
    Message: string;
    Exception: string;
    Data: T;
}