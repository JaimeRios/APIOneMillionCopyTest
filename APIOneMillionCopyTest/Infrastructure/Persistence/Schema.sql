--base de datos
--Database used Postgress on server AIVEN: https://console.aiven.io/login 

CREATE TABLE leads (
    id SERIAL PRIMARY KEY,

    nombre VARCHAR(100) NOT NULL CHECK (char_length(nombre) >= 2),

    email VARCHAR(150) NOT NULL UNIQUE
        CHECK (email ~* '^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$'),

    telefono VARCHAR(30),

    fuente VARCHAR(50) NOT NULL
        CHECK (fuente IN ('instagram', 'facebook', 'landing_page', 'referido', 'otro')),

    producto_interes VARCHAR(150),

    presupuesto NUMERIC(10,2)
        CHECK (presupuesto >= 0),

    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

--Seeds

INSERT INTO leads (nombre, email, telefono, fuente, producto_interes, presupuesto)
VALUES
('Carlos Pérez', 'carlos.perez@example.com', '3001234567', 'instagram', 'Curso de inversión', 500.00),
('María Gómez', 'maria.gomez@example.com', '3019876543', 'facebook', 'Asesoría financiera', 1200.00),
('Juan Rodríguez', 'juan.rodriguez@example.com', NULL, 'landing_page', 'Criptomonedas', 800.00),
('Laura Martínez', 'laura.martinez@example.com', '3025558899', 'referido', 'Trading avanzado', 1500.00),
('Andrés López', 'andres.lopez@example.com', '3001112233', 'instagram', NULL, NULL),
('Sofía Ramírez', 'sofia.ramirez@example.com', NULL, 'facebook', 'Fondos indexados', 300.00),
('Diego Torres', 'diego.torres@example.com', '3042223344', 'otro', 'Inversión inmobiliaria', 2000.00),
('Valentina Castro', 'valentina.castro@example.com', '3056667788', 'landing_page', NULL, 700.00),
('Miguel Herrera', 'miguel.herrera@example.com', NULL, 'referido', 'Educación financiera', NULL),
('Camila Vargas', 'camila.vargas@example.com', '3009998877', 'instagram', 'Plan de ahorro', 400.00);