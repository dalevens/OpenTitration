from pydantic_settings import BaseSettings


class Settings(BaseSettings):
    app_name: str = "OpenTitration"
    cors_origins: list[str] = ["http://localhost:3000", "http://localhost:5173"]
    iteration_setting: int = 2
    default_norm_y1: int = 6
    default_norm_y2: int = 4
    default_offset_y2: int = 2
    default_solve_method: str = "automatic"

    model_config = {"env_prefix": "OT_"}


settings = Settings()
